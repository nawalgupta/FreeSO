﻿using FSO.Client.Controllers;
using FSO.Client.UI.Controls;
using FSO.Client.UI.Framework;
using FSO.Client.Utils;
using FSO.Common.DataService.Model;
using FSO.Common.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSO.Client.UI.Panels
{
    public class UIPersonPage : UIContainer
    {
        public UIImage BackgroundContractedImage { get; set; }
        public UIImage BackgroundExpandedImage { get; set; }
        public UIImage BackgroundNameImage { get; set; }
        public UISim SimBox { get; set; }

        /** Auto wired **/
        public UIButton ExpandButton { get; set; }
        public UIButton ExpandedCloseButton { get; set; }
        public UIButton ContractButton { get; set; }
        public UIButton ContractedCloseButton { get; set; }

        public UIButton FriendshipWebButton { get; set; }
        public UILabel NameText { get; set; }

        /** Tabs **/
        public UIButton DescriptionTabButton { get; set; }
        public UIButton AccomplishmentsTabButton { get; set; }
        public UIButton RelationshipsTabButton { get; set; }
        public UIButton OptionsTabButton { get; set; }

        /** Description tab **/
        public UIImage DescriptionTabBackgroundImage { get; set; }
        public UIImage DescriptionTabImage { get; set; }
        public UIImage DescriptionBackgroundReadImage { get; set; }
        public UIImage DescriptionBackgroundWriteImage { get; set; }

        public UITextEdit DescriptionText { get; set; }
        public UISlider DescriptionSlider { get; set; }
        public UIButton DescriptionScrollUpButton { get; set; }
        public UIButton DescriptionScrollDownButton { get; set; }
        public UILabel AgeText { get; set; }

        /**
         * Accomplishments Tab
         */
        public UIButton SkillsSubTabButton { get; set; }
        public UIButton JobsSubTabButton { get; set; }
        public UIImage AccomplishmentsTabBackgroundImage { get; set; }
        public UIImage AccomplishmentsTabImage { get; set; }
        public UIImage AccomplishmentsBackgroundImage { get; set; }

        /** Skills **/

        /** Jobs **/
        public UITextEdit JobsText { get; set; }
        public UISlider JobsSlider { get; set; }
        public UIButton JobsScrollUpButton { get; set; }
        public UIButton JobsScrollDownButton { get; set; }
        public UIButton JobsHelpButton { get; set; }

        public UIImage SkillsSubTabBackgroundImage { get; set; }
        public UIImage SkillsSubTabImage { get; set; }
        public UIImage SkillsBackgroundImage { get; set; }

        public UIImage JobsSubTabBackgroundImage { get; set; }
        public UIImage JobsSubTabImage { get; set; }
        public UIImage JobsBackgroundImage { get; set; }
        public UIImage JobsHelpButtonBackgroundImage { get; set; }

        /** Relationships **/
        public UIButton OutgoingSubTabButton { get; set; }
        public UIButton IncomingSubTabButton { get; set; }

        public UIImage RelationshipsTabBackgroundImage { get; set; }
        public UIImage RelationshipsTabImage { get; set; }
        public UIImage RelationshipsBackgroundImage { get; set; }

        public UIImage OutgoingSubTabBackgroundImage { get; set; }
        public UIImage OutgoingSubTabImage { get; set; }

        public UIImage IncomingSubTabBackgroundImage { get; set; }
        public UIImage IncomingSubTabImage { get; set; }


        /** Options **/
        public UIButton AdmitCheckBox { get; set; }
        public UIButton BanCheckBox { get; set; }
        public UIButton InviteButton { get; set; }
        public UIButton KickOutButton { get; set; }
        public UIButton IgnoreButton { get; set; }

        public UIImage OptionsTabBackgroundImage { get; set; }
        public UIImage OptionsTabImage { get; set; }
        public UIImage OptionsBackgroundImage { get; set; }

        private bool Open = true;

        /**
         * Model
         */
        public Binding<Avatar> CurrentAvatar { get; internal set; }
        private bool _IsMe;

        public bool IsMe {
            get { return _IsMe; }
            set { _IsMe = value; Redraw(); }
        }

        private UIPersonPageTab _Tab = UIPersonPageTab.Description;
        private UIAccomplishmentsTab _AccomplishmentsTab = UIAccomplishmentsTab.Skills;
        private UIRelationshipsTab _RelationshipsTab = UIRelationshipsTab.Outgoing;


        public UIPersonPage()
        {
            BackgroundContractedImage = new UIImage();
            this.AddAt(0, BackgroundContractedImage);
            BackgroundExpandedImage = new UIImage();
            this.AddAt(0, BackgroundExpandedImage);
            BackgroundNameImage = new UIImage();
            this.Add(BackgroundNameImage);

            SimBox = new UISim();
            SimBox.Avatar.Scale = new Vector3(0.42f);
            SimBox.Position = new Vector2(104, 195);
            SimBox.AutoRotate = true;
            this.Add(SimBox);

            /** Description tab **/
            DescriptionTabBackgroundImage = new UIImage();
            Add(DescriptionTabBackgroundImage);
            DescriptionTabImage = new UIImage();
            Add(this.DescriptionTabImage);
            DescriptionBackgroundReadImage = new UIImage();
            Add(this.DescriptionBackgroundReadImage);
            DescriptionBackgroundWriteImage = new UIImage();
            Add(this.DescriptionBackgroundWriteImage);

            /** Accomplishments tab **/
            AccomplishmentsTabBackgroundImage = new UIImage();
            Add(AccomplishmentsTabBackgroundImage);
            AccomplishmentsTabImage = new UIImage();
            Add(AccomplishmentsTabImage);
            AccomplishmentsBackgroundImage = new UIImage();
            Add(AccomplishmentsBackgroundImage);

            SkillsSubTabBackgroundImage = new UIImage();
            Add(SkillsSubTabBackgroundImage);
            SkillsSubTabImage = new UIImage();
            Add(SkillsSubTabImage);
            SkillsBackgroundImage = new UIImage();
            Add(SkillsBackgroundImage);

            JobsSubTabBackgroundImage = new UIImage();
            Add(JobsSubTabBackgroundImage);
            JobsSubTabImage = new UIImage();
            Add(JobsSubTabImage);
            JobsBackgroundImage = new UIImage();
            Add(JobsBackgroundImage);
            JobsHelpButtonBackgroundImage = new UIImage();
            Add(JobsHelpButtonBackgroundImage);


            RelationshipsTabBackgroundImage = new UIImage();
            Add(RelationshipsTabBackgroundImage);
            RelationshipsTabImage = new UIImage();
            Add(RelationshipsTabImage);
            RelationshipsBackgroundImage = new UIImage();
            Add(RelationshipsBackgroundImage);
            OutgoingSubTabBackgroundImage = new UIImage();
            Add(OutgoingSubTabBackgroundImage);
            OutgoingSubTabImage = new UIImage();
            Add(OutgoingSubTabImage);
            IncomingSubTabBackgroundImage = new UIImage();
            Add(IncomingSubTabBackgroundImage);
            IncomingSubTabImage = new UIImage();
            Add(IncomingSubTabImage);


            /** Options **/
            OptionsTabBackgroundImage = new UIImage();
            Add(OptionsTabBackgroundImage);
            OptionsTabImage = new UIImage();
            Add(OptionsTabImage);
            OptionsBackgroundImage = new UIImage();
            Add(OptionsBackgroundImage);

            var ui = this.RenderScript("personpage.uis");

            BackgroundNameImage.With9Slice(20, 20, 0, 0);

            /**
             * Wire up behavior
             */

            /** Scroll bars **/
            this.DescriptionSlider.AttachButtons(DescriptionScrollUpButton, DescriptionScrollDownButton, 1);
            this.DescriptionText.AttachSlider(this.DescriptionSlider);

            /** Tab Buttons **/
            this.DescriptionTabButton.OnButtonClick += new ButtonClickDelegate(TabButton_OnButtonClick);
            this.AccomplishmentsTabButton.OnButtonClick += new ButtonClickDelegate(TabButton_OnButtonClick);
            this.RelationshipsTabButton.OnButtonClick += new ButtonClickDelegate(TabButton_OnButtonClick);
            this.OptionsTabButton.OnButtonClick += new ButtonClickDelegate(TabButton_OnButtonClick);
            this.SkillsSubTabButton.OnButtonClick += new ButtonClickDelegate(AccompSubTabButton_OnButtonClick);
            this.JobsSubTabButton.OnButtonClick += new ButtonClickDelegate(AccompSubTabButton_OnButtonClick);
            this.OutgoingSubTabButton.OnButtonClick += new ButtonClickDelegate(RelationshipsTabButton_OnButtonClick);
            this.IncomingSubTabButton.OnButtonClick += new ButtonClickDelegate(RelationshipsTabButton_OnButtonClick);

            /** Drag **/
            UIUtils.MakeDraggable(BackgroundContractedImage, this, true);
            UIUtils.MakeDraggable(BackgroundExpandedImage, this, true);

            
            /** Open / close **/
            ContractButton.OnButtonClick += (UIElement e) => {
                SetOpen(false);
            };
            ExpandButton.OnButtonClick += (UIElement e) => {
                SetOpen(true);
            };

            /** Default state **/
            CurrentTab = UIPersonPageTab.Description;
            CurrentAccomplishmentsTab = UIAccomplishmentsTab.Skills;
            CurrentRelationshipsTab = UIRelationshipsTab.Outgoing;

            CurrentAvatar = new Binding<Avatar>()
                .WithBinding(DescriptionText, "CurrentText", "Avatar_Description")
                .WithBinding(this, "HeadOutfitId", "Avatar_Appearance.AvatarAppearance_HeadOutfitID")
                .WithBinding(this, "SimBox.Avatar.BodyOutfitId", "Avatar_Appearance.AvatarAppearance_BodyOutfitID")
                .WithBinding(this, "AvatarName", "Avatar_Name");
            
            Redraw();
        }

        public ulong HeadOutfitId
        {
            set
            {
                //4514010628109
                SimBox.Avatar.HeadOutfitId = value;
            }
            get
            {
                return SimBox.Avatar.HeadOutfitId;
            }
        }

        public string AvatarName
        {
            set
            {
                NameText.Caption = value;
                ResizeNameLabel();
            }
            get
            {
                return NameText.Caption;
            }
        }

        private void ResizeNameLabel()
        {
            var style = NameText.CaptionStyle;
            var width = style.MeasureString(NameText.Caption).X;
            var backgroundWidth = width + 40.0f;
            backgroundWidth = Math.Max(backgroundWidth, 106);

            BackgroundNameImage.SetSize(backgroundWidth, BackgroundNameImage.Height);
            BackgroundNameImage.Position = new Vector2(103.0f - (backgroundWidth / 2.0f), 0.0f);
            //var textX = BackgroundNameImage.X + ((BackgroundNameImage.Width / 2.0f) - (width / 2.0f));

            NameText.Size = new Vector2(BackgroundNameImage.Width, BackgroundNameImage.Height);
            NameText.Position = new Vector2(BackgroundNameImage.Position.X, 0);
        }

        void RelationshipsTabButton_OnButtonClick(UIElement button)
        {
            if (button == this.OutgoingSubTabButton)
            {
                CurrentRelationshipsTab = UIRelationshipsTab.Outgoing;
            }
            else if (button == this.IncomingSubTabButton)
            {
                CurrentRelationshipsTab = UIRelationshipsTab.Incoming;
            }
        }

        void AccompSubTabButton_OnButtonClick(UIElement button)
        {
            if (button == this.SkillsSubTabButton)
            {
                CurrentAccomplishmentsTab = UIAccomplishmentsTab.Skills;
            }
            else if (button == this.JobsSubTabButton)
            {
                CurrentAccomplishmentsTab = UIAccomplishmentsTab.Jobs;
            }
        }

        void TabButton_OnButtonClick(UIElement button)
        {
            if (button == this.DescriptionTabButton)
            {
                CurrentTab = UIPersonPageTab.Description;
            }
            else if (button == this.AccomplishmentsTabButton)
            {
                CurrentTab = UIPersonPageTab.Accomplishments;
            }
            else if (button == this.RelationshipsTabButton)
            {
                CurrentTab = UIPersonPageTab.Relationships;
            }
            else if (button == this.OptionsTabButton)
            {
                CurrentTab = UIPersonPageTab.Options;
            }
        }

        public UIPersonPageTab CurrentTab
        {
            get
            {
                return _Tab;
            }
            set
            {
                _Tab = value;
                DescriptionTabButton.Selected = _Tab == UIPersonPageTab.Description;
                AccomplishmentsTabButton.Selected = _Tab == UIPersonPageTab.Accomplishments;
                RelationshipsTabButton.Selected = _Tab == UIPersonPageTab.Relationships;
                OptionsTabButton.Selected = _Tab == UIPersonPageTab.Options;
                Redraw();
            }
        }

        public UIAccomplishmentsTab CurrentAccomplishmentsTab
        {
            get
            {
                return _AccomplishmentsTab;
            }
            set
            {
                _AccomplishmentsTab = value;
                SkillsSubTabButton.Selected = _AccomplishmentsTab == UIAccomplishmentsTab.Skills;
                JobsSubTabButton.Selected = _AccomplishmentsTab == UIAccomplishmentsTab.Jobs;
                Redraw();
            }
        }

        public UIRelationshipsTab CurrentRelationshipsTab
        {
            get
            {
                return _RelationshipsTab;
            }
            set
            {
                _RelationshipsTab = value;
                OutgoingSubTabButton.Selected = _RelationshipsTab == UIRelationshipsTab.Outgoing;
                IncomingSubTabButton.Selected = _RelationshipsTab == UIRelationshipsTab.Incoming;
                Redraw();
            }
        }


        private int bodyID = 0;

        public void SetOpen(bool open)
        {
            this.Open = open;
            Redraw();
            FindController<PersonPageController>().RefreshData(_Tab);
        }

        private void Redraw()
        {
            var isOpen = Open == true;
            var isClosed = Open == false;

            BackgroundContractedImage.Visible = isClosed;
            BackgroundExpandedImage.Visible = isOpen;
            ContractButton.Visible = isOpen;
            ContractedCloseButton.Visible = isClosed;
            ExpandButton.Visible = isClosed;
            ExpandedCloseButton.Visible = isOpen;

            var isDesc = _Tab == UIPersonPageTab.Description;
            var isAccomp = _Tab == UIPersonPageTab.Accomplishments;
            var isSkills = isAccomp && (_AccomplishmentsTab == UIAccomplishmentsTab.Skills);
            var isJobs = isAccomp && (_AccomplishmentsTab == UIAccomplishmentsTab.Jobs);
            var isRelationships = _Tab == UIPersonPageTab.Relationships;
            var isOutgoing = _RelationshipsTab == UIRelationshipsTab.Outgoing;
            var isIncoming = _RelationshipsTab == UIRelationshipsTab.Incoming;
            var isOptions = _Tab == UIPersonPageTab.Options;
            
            /** Tab Images **/
            this.DescriptionTabButton.Visible = isOpen;
            this.DescriptionTabBackgroundImage.Visible = isOpen && !isDesc;
            this.DescriptionTabImage.Visible = isOpen && isDesc;
            this.DescriptionBackgroundReadImage.Visible = isOpen && isDesc && !IsMe;
            this.DescriptionBackgroundWriteImage.Visible = isOpen && isDesc && IsMe;

            this.AccomplishmentsTabButton.Visible = isOpen;
            this.AccomplishmentsTabBackgroundImage.Visible = isOpen && !isAccomp;
            this.AccomplishmentsTabImage.Visible = isOpen && isAccomp;
            this.AccomplishmentsBackgroundImage.Visible = isOpen && isAccomp;
            this.SkillsSubTabBackgroundImage.Visible = isOpen && isAccomp && !isSkills;
            this.SkillsSubTabImage.Visible = isOpen && isAccomp && isSkills;
            this.SkillsBackgroundImage.Visible = isOpen && isAccomp && isSkills;
            this.JobsSubTabBackgroundImage.Visible = isOpen && isAccomp && !isJobs;
            this.JobsSubTabImage.Visible = isOpen && isAccomp && isJobs;
            this.JobsBackgroundImage.Visible = isOpen && isAccomp && isJobs;
            this.JobsHelpButtonBackgroundImage.Visible = false;

            RelationshipsTabButton.Visible = isOpen;
            RelationshipsTabBackgroundImage.Visible = isOpen && !isRelationships;
            RelationshipsTabImage.Visible = isOpen && isRelationships;
            RelationshipsBackgroundImage.Visible = isOpen && isRelationships;
            OutgoingSubTabBackgroundImage.Visible = isOpen && isRelationships && !isOutgoing;
            OutgoingSubTabImage.Visible = isOpen && isRelationships && isOutgoing;
            IncomingSubTabBackgroundImage.Visible = isOpen && isRelationships && !isIncoming;
            IncomingSubTabImage.Visible = isOpen && isRelationships && isIncoming;

            OptionsTabButton.Visible = isOpen;
            OptionsTabBackgroundImage.Visible = isOpen && !isOptions;
            OptionsTabImage.Visible = isOpen && isOptions;
            OptionsBackgroundImage.Visible = isOpen && isOptions;

            if (isClosed)
            {
                this.ChildrenWithinIdRange(400, 1299).ForEach(x => x.Visible = false);
                return;
            }

            /** Description tab **/
            this.ChildrenWithinIdRange(400, 499).ForEach(x => x.Visible = isDesc);


            /** Accomplishments **/
            this.ChildrenWithinIdRange(500, 599).ForEach(x => x.Visible = isAccomp);
            this.ChildrenWithinIdRange(600, 699).ForEach(x => x.Visible = isSkills);
            this.ChildrenWithinIdRange(900, 999).ForEach(x => x.Visible = isJobs);

            /** Relationships **/
            this.ChildrenWithinIdRange(1000, 1099).ForEach(x => x.Visible = isRelationships);

            /** Options **/
            this.ChildrenWithinIdRange(700, 799).ForEach(x => x.Visible = isOptions);
        }
    }

    public enum UIPersonPageTab
    {
        Description,
        Accomplishments,
        Relationships,
        Options
    }

    public enum UIAccomplishmentsTab
    {
        Skills,
        Jobs
    }

    public enum UIRelationshipsTab
    {
        Outgoing,
        Incoming
    }
}