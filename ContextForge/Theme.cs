namespace ContextForge
{
    /// <summary>
    /// Dark slate palette. Surface and tonal-surface steps, all with white-text contrast of AA or better.
    /// </summary>
    public static class Theme
    {
        // Surface
        public static readonly Color Background = ColorTranslator.FromHtml("#0b1620"); // form, header, menu
        public static readonly Color Pane = ColorTranslator.FromHtml("#1f2933"); // tree + result boxes
        public static readonly Color ButtonBack = ColorTranslator.FromHtml("#343d47"); // buttons, menu highlight
        public static readonly Color ButtonHover = ColorTranslator.FromHtml("#4a535b"); // hover, borders
        public static readonly Color ButtonDown = ColorTranslator.FromHtml("#616971"); // pressed

        // Tonal surface
        public static readonly Color Input = ColorTranslator.FromHtml("#102432"); // filter textbox
        public static readonly Color Band = ColorTranslator.FromHtml("#243744"); // top entities band
        public static readonly Color Chip = ColorTranslator.FromHtml("#3a4a57"); // entity buttons
        public static readonly Color ChipHover = ColorTranslator.FromHtml("#505f6a");
        public static readonly Color ChipActive = ColorTranslator.FromHtml("#67747e"); // entity in use as filter
        public static readonly Color Accent = ColorTranslator.FromHtml("#8ab4d8"); // file headers in code output
        public static readonly Color Line = ColorTranslator.FromHtml("#7e8992"); // tree lines, subtle accents

        // Text
        public static readonly Color Text = ColorTranslator.FromHtml("#e6edf3");

        public static void StyleButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = ButtonBack;
            button.ForeColor = Text;
            button.FlatAppearance.BorderColor = ButtonHover;
            button.FlatAppearance.MouseOverBackColor = ButtonHover;
            button.FlatAppearance.MouseDownBackColor = ButtonDown;
            button.UseVisualStyleBackColor = false;
        }

        public static void StyleChip(Button chip)
        {
            chip.FlatStyle = FlatStyle.Flat;
            chip.BackColor = Chip;
            chip.ForeColor = Text;
            chip.FlatAppearance.BorderColor = ChipHover;
            chip.FlatAppearance.MouseOverBackColor = ChipHover;
            chip.FlatAppearance.MouseDownBackColor = ChipActive;
            chip.UseVisualStyleBackColor = false;
        }

        public static void StyleActiveChip(Button chip)
        {
            chip.BackColor = ChipActive;
            chip.FlatAppearance.BorderColor = Text;
            chip.FlatAppearance.MouseOverBackColor = ChipActive;
        }

        public static void StylePane(Control pane)
        {
            pane.BackColor = Pane;
            pane.ForeColor = Text;
        }

        public static void StyleMenu(MenuStrip menu)
        {
            menu.Renderer = new ToolStripProfessionalRenderer(new PaletteColorTable());
            menu.BackColor = Background;
            menu.ForeColor = Text;

            foreach (ToolStripItem item in menu.Items)
                StyleMenuItem(item);
        }

        private static void StyleMenuItem(ToolStripItem item)
        {
            item.ForeColor = Text;

            if (item is ToolStripMenuItem menuItem)
            {
                menuItem.DropDown.BackColor = Background;
                foreach (ToolStripItem child in menuItem.DropDownItems)
                    StyleMenuItem(child);
            }
        }

        private sealed class PaletteColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => Background;
            public override Color MenuStripGradientEnd => Background;
            public override Color ToolStripDropDownBackground => Background;
            public override Color ImageMarginGradientBegin => Background;
            public override Color ImageMarginGradientMiddle => Background;
            public override Color ImageMarginGradientEnd => Background;
            public override Color MenuBorder => ButtonHover;
            public override Color MenuItemBorder => ButtonHover;
            public override Color MenuItemSelected => ButtonBack;
            public override Color MenuItemSelectedGradientBegin => ButtonBack;
            public override Color MenuItemSelectedGradientEnd => ButtonBack;
            public override Color MenuItemPressedGradientBegin => ButtonBack;
            public override Color MenuItemPressedGradientMiddle => ButtonBack;
            public override Color MenuItemPressedGradientEnd => ButtonBack;
            public override Color SeparatorDark => ButtonHover;
            public override Color SeparatorLight => ButtonHover;
        }
    }
}