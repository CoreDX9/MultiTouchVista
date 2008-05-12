﻿using System;
using System.Windows.Controls;
using Multitouch.Framework.WPF.Input;

namespace Multitouch.Framework.WPF.Controls
{
	public class Button : System.Windows.Controls.Button
	{
		public Button()
		{
			AddHandler(MultitouchScreen.NewContactEvent, (NewContactEventHandler)OnNewContact);
			AddHandler(MultitouchScreen.ContactRemovedEvent, (ContactEventHandler)OnContactRemoved);
			AddHandler(MultitouchScreen.ContactLeaveEvent, (ContactEventHandler)OnContactLeave);
			AddHandler(MultitouchScreen.ContactEnterEvent, (ContactEventHandler)OnContactEnter);
		}

		void OnContactEnter(object sender, ContactEventArgs e)
		{
			if(e.GetContacts(this, MatchCriteria.LogicalParent).Count == 1 && !IsPressed && e.Captured == this)
				IsPressed = true;
		}

		void OnContactLeave(object sender, ContactEventArgs e)
		{
			if(e.GetContacts(this, MatchCriteria.LogicalParent).Count == 1 && IsPressed)
				IsPressed = false;
		}

		void OnContactRemoved(object sender, ContactEventArgs e)
		{
			if(e.GetContacts(this, MatchCriteria.LogicalParent).Count == 0 && IsPressed)
			{
				IsPressed = false;
				if(ClickMode == ClickMode.Release)
					OnClick();
			}
		}

		void OnNewContact(object sender, NewContactEventArgs e)
		{
			if (e.GetContacts(this, MatchCriteria.LogicalParent).Count == 1)
			{
				IsPressed = true;
				if (ClickMode == ClickMode.Press)
					OnClick();
			}
		}
	}
}