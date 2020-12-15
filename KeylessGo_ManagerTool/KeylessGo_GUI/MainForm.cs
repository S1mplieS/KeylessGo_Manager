﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using libKeylessGo;

namespace KeylessGo_GUI
{
  public partial class MainForm : Form
  {
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
    (
      int nLeftRect, 
      int nTopRect, 
      int nRightRect,
      int nBottomRect, 
      int nWidthEllipse, 
      int nHeightEllispe
    );

    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      // Rounded Corners for Form
      Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

      // Gradient Colors for Side Menue
      sideMenuePanel.ColorTop = Color.FromArgb(111, 134, 214);
      sideMenuePanel.ColorBottom = Color.FromArgb(72, 198, 239);

      // Button Icons
      buttonExitProg.Image = KeylessGo_GUI.Properties.Resources.exit_program_icon;
      buttonAddEntry.Image = KeylessGo_GUI.Properties.Resources.add_entry_icon;
      buttonImportFile.Image = KeylessGo_GUI.Properties.Resources.import_file_icon;
      buttonSyncDevice.Image = KeylessGo_GUI.Properties.Resources.sync_icon;
      buttonSettings.Image = KeylessGo_GUI.Properties.Resources.settings_icon;

      buttonSoftwareInfo.Image = KeylessGo_GUI.Properties.Resources.software_icon;
      buttonDeviceInfo.Image = KeylessGo_GUI.Properties.Resources.device_icon;

      // FlowLayoutPanel
      entryFlowLayoutPanel.HorizontalScroll.Visible = false;

      // Test & Debug
      Dictionary<Credential.UserDataType, string> dictionary = new Dictionary<Credential.UserDataType, string>();
      dictionary.Add(Credential.UserDataType.Login, "MinecraftGamer420");
      dictionary.Add(Credential.UserDataType.Password, "123456789");
      dictionary.Add(Credential.UserDataType.Title, "LOL");
      dictionary.Add(Credential.UserDataType.Website, "www.google.com");

      Credential cred = new Credential(dictionary);

      GUIEntryCreator entryCreator = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator2 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator3 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator4 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator5 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator6 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator7 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator8 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator9 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
      GUIEntryCreator entryCreator0 = new GUIEntryCreator(entryFlowLayoutPanel, cred);
    }

    private void panelInformation_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
      }
    }

    private void buttonExitProg_Click(object sender, EventArgs e)
    {
      Environment.Exit(0);
    }
  }
}