using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using IniParser;
using System.Xml;
using System.IO;
using System.Threading;
namespace compass_bundle_ui
{
  
    public partial class main : Form
    {
        private string newDirName;
        private string rubyPath;
        private string compassPath;
        private string dirListPath;
        private string frameworkPath;
        private confForm cForm=null;
        private aboutForm aForm = null;
        private string[] frameworkList = null;
        private listItem[] lis=null;
        private int listIndex=0;
        private bool ballonShowed = false;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem0;
        public main()
        {
            IniParser.FileIniDataParser parser = new FileIniDataParser();
            IniData parsedData = parser.LoadFile("setting/ui-setting.ini");
            rubyPath = parsedData["PATH"]["ruby"];
            compassPath = parsedData["PATH"]["compass"];
            dirListPath = parsedData["PATH"]["dirlist"];
            frameworkPath = parsedData["PATH"]["framework"];
            ///

            components = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem0 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            
            // Initialize contextMenu1
            this.contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { this.menuItem0,this.menuItem1 });

            
            // Initialize menuItem1
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "E&xit";
            this.menuItem1.Click += new System.EventHandler(this.exitWindowHander);

            this.menuItem0.Index = 0;
            this.menuItem0.Text = "H&ide";
            this.menuItem0.Click += new System.EventHandler(this.showWindowHander);
            // Set up how the form should be displayed.
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Compass Bundle UI";

            // Create the NotifyIcon.
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            
            notifyIcon1.Icon = new Icon(Directory.GetCurrentDirectory()+"/icon/compass_icon.ico");

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon1.ContextMenu = this.contextMenu1;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon1.Text = "Compass Bundle UI";
            notifyIcon1.Visible = true;

            // Handle the DoubleClick event to activate the form.
            notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            //MessageBox.Show(compassBatPath);
            InitializeComponent();
            this.loadList();
            this.add2CLI("load the default folder list.");
            this.write2Xml();
            this.initCreateList();
            this.Show();
        }
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                //MessageBox.Show("sss");
                components.Dispose();
                this.stopWatchAll();
            }
            base.Dispose(disposing);
        }
        private void initCreateList()
        {
            string frameworkDir = frameworkPath;
            DirectoryInfo dir = new DirectoryInfo(frameworkDir);
            this.frameworkList = new string[100];
            int findex=0;
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                this.frameworkList[findex++] = di.Name;
                if (di.Name != "compass")
                {
                    System.Windows.Forms.ToolStripMenuItem tmpItem = new System.Windows.Forms.ToolStripMenuItem();
                    tmpItem.Name = dir.Name + "Item";
                    tmpItem.Size = new System.Drawing.Size(152, 22);
                    tmpItem.Text = "&" + di.Name;
                    tmpItem.Tag = di.Name;
                    tmpItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
                    this.createToolStripMenuItem.DropDownItems.Add(tmpItem);
                }
                
            }
        }
        private void loadList()
        {
            this.lis=new listItem[100];
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(this.dirListPath);
            XmlNodeList xnl = xmlDoc.SelectSingleNode("Dirs").ChildNodes;
            this.dirGrid.Rows.Clear();
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;
                this.addListItem(xe.InnerText, xe.GetAttribute("watch") == "true" ? true : false, false);
                if (xe.GetAttribute("watch") == "true")
                {
                    this.watchPathProcess(xe.InnerText);
                }
                //this.lis[this.listIndex++] = li;
            }
            //MessageBox.Show("OK");
            //MessageBox.Show(this.lis[1].path);
            //xmlfile
            //dirListPath

        }
        
        private bool addListItem(string path, bool ifWathed,bool relWriteXml=false)
        {
            // whether the path is in the lis at all;
            if (this.listIndex > 0)
            {
                foreach (listItem li in this.lis)
                {
                    if (li != null)
                    {
                        if (li.path == path)
                        {
                            MessageBox.Show("This path is added already!");
                            return false;
                        }
                    }
                    else 
                    {
                        break;
                    }
                    
                }
            }
            //todo 如果路径被删除了的话，需要重新整理xml
            if (Directory.Exists(path))
            {
                listItem l = new listItem();
                l.path = path;
                l.ifWathed = ifWathed;
                this.lis[this.listIndex++] = l;
                this.dirGrid.Rows.Add(new Object[] { path, ifWathed, "Delete" });
                if (relWriteXml)
                {
                    this.write2Xml();
                }
                return true;
            }
            return false;
            
        }
        private void add2CLI(String txt)
        {
            txtCLI.Text = txtCLI.Text + "\n--------------------\n" + txt;
            txtCLI.SelectionStart = txtCLI.Text.Length;
            txtCLI.ScrollToCaret();
        }
        private bool write2Xml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(this.dirListPath);
            XmlNode root = xmlDoc.SelectSingleNode("Dirs");
            root.RemoveAll();
            foreach (listItem li in this.lis)
            {
                if (li != null)
                {
                    if (li.readForDel==false&&Directory.Exists(li.path))
                    {
                        XmlElement xe1 = xmlDoc.CreateElement("Dir");//创建一个节点 
                        xe1.InnerText = li.path;
                        xe1.SetAttribute("watch", li.ifWathed ? "true" : "false");
                        root.AppendChild(xe1);
                    }
                    
                }
                else
                {
                    break;
                }
                
            }
            xmlDoc.Save(this.dirListPath);
            return true;
        }
        private bool delListItem(string path)
        {
            this.listIndex=0;
            listItem[] nlis=new listItem[100];
            foreach (listItem li in this.lis)
            {
                if (li != null)
                {
                    if (li.path == path)
                    {
                        li.readForDel = true;
                    }
                    nlis[this.listIndex++] = li;
                }
                else
                {
                    break;
                }
            }
            this.lis = nlis;

            return true;
        }
        private bool modifyListItem(String path, bool ifWatched)
        {
            this.listIndex = 0;
            listItem[] nlis = new listItem[100];
            foreach (listItem li in this.lis)
            {
                if (li != null)
                {
                    if (li.path == path)
                    {
                        li.ifWathed = ifWatched;
                    }
                    nlis[this.listIndex++] = li;
                }
                else
                {
                    break;
                }
            }
            this.lis = nlis;
            return true;
        }
        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.Activate();
        }
        private void exitWindowHander(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.exitWindow();
            this.stopWatchAll();
        }
        private void showWindowHander(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            //this.Show();
            if (this.Visible)
            {
                this.Hide();
                this.menuItem0.Text = "S&how";
            }
            else 
            {
                this.Show();
                this.menuItem0.Text = "H&ide";
            }
            
        }
        
        private void exitWindow()
        {
            this.notifyIcon1.Dispose();
            this.Close();
            this.Dispose();
        }

        private void newDirDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
       

        private void dirGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex ==-1) 
            {
                return;
            }
            DataGridViewCell cell = (DataGridViewCell)
            this.dirGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //cell.
            //explorer 
            if (e.ColumnIndex  == 0)
            {
                // open explore
                this.ExecuteCommandSync("explorer.exe " + cell.Value.ToString());
                //Process.Start("explorer.exe", cell.Value.ToString());
                //MessageBox.Show();
            }
            else if (e.ColumnIndex == 1)
            {
                if (cell.Value.Equals(true))
                {
                    //stop the watch process
                    this.modifyListItem(this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),false);
                    this.dirGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    this.stopWatch(this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.add2CLI("Don't watch folder \"" + this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString() + "\"!");
                }
                else 
                {
                    this.modifyListItem(this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), true);
                    this.dirGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                    // start watch process
                    //ProcessStartInfo startInfo = new ProcessStartInfo(compassBatPath);
                    //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //Process.Start(startInfo);
                    //startInfo.Arguments = "watch \"" + this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString()+"\"";
                    //Process.Start(startInfo);
                    this.newWatch(this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.add2CLI("Watch folder \"" + this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString()+"\"!");
                }
                this.write2Xml();
            }
            else if (e.ColumnIndex == 2) { 
                // delete the project from ini and reload the list
                this.dirGrid.Rows[e.RowIndex].Visible = false;
                this.delListItem(this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                
                this.add2CLI("delete the folder " + this.dirGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.write2Xml();
            }
            
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aForm = new aboutForm();
            aForm.Owner = this;
            //cForm.a
            aForm.ShowDialog(this);
            //MessageBox.Show("Compass Bundle UI\n@cokeetang\ntqp860618@gmail.com\n V 0.1","About me!");
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(getDefaultBrowser());
            Process.Start(getDefaultBrowser(), "http://weibo.com/cokeetang");
        }
        private string getDefaultBrowser()
        {
            string browser = string.Empty;
            RegistryKey key = null;
            try
            {
                key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                //trim off quotes
                browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
                if (!browser.EndsWith("exe"))
                {
                    //get rid of everything after the ".exe"
                    browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
                }
            }
            finally
            {
                if (key != null) key.Close();
            }
            return browser;
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cForm = new confForm();
            cForm.Owner = this;
            //cForm.a
            cForm.ShowDialog(this);
        }
        public void ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo procStartInfo =
                    new ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);
                this.add2CLI(result);
            }
            catch (Exception objException)
            {

                // Log the exception
            }
        }
        public void watchPathProcess(object path)
        {
            try
            {
                string command = rubyPath + " " + compassPath + " watch \"" + path + "\"";
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                ProcessStartInfo procStartInfo =
                    new ProcessStartInfo(rubyPath);
                procStartInfo.Arguments = compassPath + " watch \"" + path + "\"";

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                Process proc = new Process();
                proc.StartInfo = procStartInfo;

                listItem[] nlis = new listItem[100];
                this.listIndex = 0;
                foreach (listItem li in this.lis)
                {
                    if (li != null)
                    {
                        if (li.path == path)
                        {
                            li.watchProcess = proc;
                        }
                        nlis[this.listIndex++] = li;
                    }
                    else
                    {
                        break;
                    }
                }
                this.lis = nlis;
                proc.Start();

                // Get the output into a string
                //string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                //Console.WriteLine(result);
                //this.add2CLI(result);
            }
            catch (Exception objException)
            {

                // Log the exception
            }
        }
        private bool stopWatchAll()
        {
            foreach (listItem li in this.lis)
            {
                if (li != null)
                {
                    if (li.ifWathed&&li.watchProcess!=null)
                    {
                        this.stopWatch(li.path);
                    }
                    
                }
                else 
                {
                    break;
                }
            }
            return true;
        }
        private bool stopWatch(string path)
        {
            foreach (listItem li in this.lis)
            {
                if (li != null)
                {
                    if (li.path == path)
                    {
                        li.ifWathed = false;
//                        if (li.watchThread != null)
 //                       {
 //                           li.watchThread.Abort();
//                            li.watchThread = null;
  //                      }
                        if (li.watchProcess != null)
                        {
                            //li.watchProcess.CloseMainWindow();
                            //li.watchProcess.Close();
                            //li.watchProcess.Dispose();
                            if (!li.watchProcess.HasExited)
                            {
                                li.watchProcess.Kill();
                            }
                            

                        }
                        
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return true;
        }
        private bool newWatch(string path)
        {
            
            Thread objThread = new Thread(new ParameterizedThreadStart(watchPathProcess));
            //Make the thread as background thread.
            objThread.IsBackground = true;
            //Set the Priority of the thread.
            objThread.Priority = ThreadPriority.AboveNormal;
            //Start the thread.
            objThread.Start(path);
            listItem[] nlis = new listItem[100];
            this.listIndex = 0;
            foreach (listItem li in this.lis)
            {
                if (li != null)
                {
                    if (li.path == path)
                    {
                        li.ifWathed = true;
                        li.watchThread = objThread;
                    }
                    nlis[this.listIndex++] = li;
                }
                else
                {
                    break;
                }
            }
            this.lis = nlis;
            return true;
        }
        public void ExecuteCommandAsync(string command)
        {
            try
            {
                //Asynchronously start the Thread to process the Execute command request.
                Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
                //Make the thread as background thread.
                objThread.IsBackground = true;
                //Set the Priority of the thread.
                objThread.Priority = ThreadPriority.AboveNormal;
                //Start the thread.
                objThread.Start(command);
            }
            catch (ThreadStartException objException)
            {
                // Log the exception
            }
            catch (ThreadAbortException objException)
            {
                // Log the exception
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            string useFramework = "";
            if (item.Tag != "default")
            {
                useFramework = " --using " + item.Tag;
            }
            DialogResult result = newDirDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                newDirName = newDirDialog.SelectedPath;
                this.ExecuteCommandAsync(rubyPath + " " + compassPath + " create \"" + newDirName + "\"" + useFramework);
                //Process.Start("d:/tmp/compass-bundle/compass.bat","create "+newDirName);
                this.addListItem(newDirName, false, true);
                this.add2CLI("add a new folder");
            }
            
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.menuItem0.Text = "S&how";
            if (!this.ballonShowed)
            {
                this.notifyIcon1.ShowBalloonTip(500, "Tips:", "The app is just hidden here!", ToolTipIcon.Info);
                this.ballonShowed = true;
            }
            
            e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void main_MinimumSizeChanged(object sender, EventArgs e)
        {

        }

     
    }
    public class listItem {
        public string path;
        public bool ifWathed;
        public bool readForDel = false;
        public Thread watchThread = null;
        public Process watchProcess = null;
    }

}
