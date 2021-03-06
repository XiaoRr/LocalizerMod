﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Localizer.DataStructures;

namespace Localizer.UI
{
	public class Manager : UIState
	{
		public UIList modList;
		public UITextPanel<string> backButton;
		public UITextPanel<string> exportAllButton;

		private UIElement uIElement;
		private UIPanel uIPanel;

		public override void OnInitialize()
		{
			uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(600f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-220f, 1f);
			uIElement.HAlign = 0.5f;

			uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIPanel.PaddingTop = 0f;
			uIElement.Append(uIPanel);

			modList = new UIList();
			modList.Width.Set(-25f, 1f);
			modList.Height.Set(-50f, 1f);
			modList.Top.Set(50f, 0f);
			modList.ListPadding = 5f;
			uIPanel.Append(modList);

			backButton = new UITextPanel<string>("Back");
			backButton.OnClick += BackClick;
			backButton.OnMouseOver += UICommon.FadedMouseOver;
			backButton.OnMouseOut += UICommon.FadedMouseOut;
			uIPanel.Append(backButton);

			Append(uIElement);

			LoadModList();
		}

		private static void BackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(11, -1, -1, 1, 1f, 0f);
			Main.menuMode = 0;
		}

		public void LoadModList()
		{
			foreach (var mod in ModLoader.LoadedMods)
			{
				var modBox = new UITextPanel<string>(mod.Name);
				modList.Add(modBox);
			}
		}
	}
}
