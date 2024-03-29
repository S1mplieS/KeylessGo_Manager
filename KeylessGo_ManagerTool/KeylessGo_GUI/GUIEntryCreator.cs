﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using libKeylessGo;

namespace KeylessGo_GUI
{
  public class GUIEntryCreator
  {
    public Panel entryPanel;
    public PictureBox entryIcon;
    public Label entryTitle;
    public LinkLabel entryWebsite;
    public Label entryUsername;
    public Label entryPassword;
    public Button entryEdit;
    public Button entryDelete;

    /// <summary>
    /// Constructor for GUIEntryCreator. Initializes all user controls.
    /// </summary>
    /// <param name="parent">Parent Panel (Control)</param>
    /// <param name="credentialInfo">Credential data</param>
    /// <param name="mouseDeleteEventHandler">Event Handler for delete button</param>
    /// <param name="mouseEditEventHandler">Event Handler for edit button</param>
    public GUIEntryCreator(Panel parent, Credential credentialInfo, MouseEventHandler mouseDeleteEventHandler, MouseEventHandler mouseEditEventHandler)
    {
      entryPanel = new Panel();
      entryPanel.Size = new Size(parent.Width - 17 , 80);
      entryPanel.BackColor = Color.White;
      entryPanel.Anchor = AnchorStyles.Top;
      entryPanel.Location = new Point(0, parent.Controls.Count * 80);
      entryPanel.Margin = new Padding(0, 3, 0, 0);

      Initialize(credentialInfo, parent.Width, mouseDeleteEventHandler, mouseEditEventHandler);

      parent.Controls.Add(entryPanel);
    }

    /// <summary>
    /// Initialize all Controls and add them to the panel
    /// </summary>
    /// <param name="credentialInfo">Credential info</param>
    /// <param name="parentWidth">Width of parent panel</param>
    /// <param name="mouseDeleteEventHandler">Event Handler for delete button</param>
    /// <param name="mouseEditeventHandler">Event Handler for edit button</param>
    private void Initialize(Credential credentialInfo, int parentWidth, MouseEventHandler mouseDeleteEventHandler, MouseEventHandler mouseEditeventHandler)
    {
      // Entry Icon
      entryIcon = new PictureBox();
      entryIcon.Size = new Size(40, 40);
      entryIcon.Image = KeylessGo_GUI.Properties.Resources.software_icon;
      entryIcon.SizeMode = PictureBoxSizeMode.Zoom;
      entryIcon.Location = new Point(20, 20);

      // Entry Title
      entryTitle = new Label();
      entryTitle.Font = new Font("Calibri", 14, FontStyle.Bold);
      entryTitle.Text = credentialInfo.GetData(Credential.UserDataType.Title);
      entryTitle.Location = new Point(85, 20);

      // Entry Username
      entryUsername = new Label();
      entryUsername.Font = new Font("Calibri", 12, FontStyle.Regular);
      entryUsername.Text = string.Format("Username: {0}", credentialInfo.GetData(Credential.UserDataType.Email));
      entryUsername.Location = new Point(260, 20);
      entryUsername.AutoSize = true;

      // Entry Password
      entryPassword = new Label();
      entryPassword.Font = new Font("Calibri", 12, FontStyle.Regular);

      string passwordString = "Password: ";
      for(int i = 0; i < credentialInfo.GetData(Credential.UserDataType.Password).Length; i++)
      {
        passwordString += "*";
      }

      entryPassword.Text = passwordString;
      entryPassword.Location = new Point(260, 40);
      entryPassword.AutoSize = true;

      // Entry Website Link
      string websiteLink = credentialInfo.GetData(Credential.UserDataType.Website);
      if(string.IsNullOrEmpty(websiteLink))
      {
        entryWebsite = new LinkLabel();
        entryWebsite.Text = websiteLink;
        entryWebsite.Font = new Font("Calibri", 12, FontStyle.Regular);
        entryWebsite.Location = new Point(85, 40);
        entryWebsite.AutoSize = true;

        try
        {
          entryIcon.LoadAsync(string.Format(@"https://{0}/favicon.ico", websiteLink));
        }
        catch(Exception ex)
        {

        }
      }

      // Edit Entry Button
      entryEdit = new Button();
      entryEdit.Text = "";
      entryEdit.Image = KeylessGo_GUI.Properties.Resources.edit_entry_icon;
      entryEdit.Size = new Size(40, 40);
      entryEdit.Location = new Point(parentWidth - 107, 20);
      entryEdit.FlatStyle = FlatStyle.Flat;
      entryEdit.FlatAppearance.BorderSize = 0;
      entryEdit.MouseClick += mouseEditeventHandler;

      // Edit Delete Button
      entryDelete = new Button();
      entryDelete.Text = "";
      entryDelete.Image = KeylessGo_GUI.Properties.Resources.delete_entry_icon;
      entryDelete.Size = new Size(40, 40);
      entryDelete.Location = new Point(parentWidth - 67, 20);
      entryDelete.FlatStyle = FlatStyle.Flat;
      entryDelete.FlatAppearance.BorderSize = 0;
      entryDelete.MouseClick += mouseDeleteEventHandler;

      // Add Controls
      entryPanel.Controls.Add(entryIcon);
      entryPanel.Controls.Add(entryTitle);
      entryPanel.Controls.Add(entryUsername);
      entryPanel.Controls.Add(entryPassword);
      entryPanel.Controls.Add(entryWebsite);
      entryPanel.Controls.Add(entryEdit);
      entryPanel.Controls.Add(entryDelete);
    }
  }
}
