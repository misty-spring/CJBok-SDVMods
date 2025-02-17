using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace CJBCheatsMenu.Framework.Components;

/// <summary>A checkbox UI option.</summary>
internal class CheatsOptionsCheckbox : BaseOptionsElement
{
    /*********
    ** Fields
    *********/
    /// <summary>A callback to invoke when the value changes.</summary>
    private readonly Action<bool> SetValue;


    /*********
    ** Accessors
    *********/
    /// <summary>Whether the checkbox is currently checked.</summary>
    public bool IsChecked { get; private set; }


    /*********
    ** Public methods
    *********/
    /// <summary>Construct an instance.</summary>
    /// <param name="label">The checkbox label.</param>
    /// <param name="value">The initial value to set.</param>
    /// <param name="setValue">A callback to invoke when the value changes.</param>
    public CheatsOptionsCheckbox(string label, bool value, Action<bool> setValue)
        : base(label, -1, -1, 9 * Game1.pixelZoom, 9 * Game1.pixelZoom, 0)
    {
        this.IsChecked = value;
        this.SetValue = setValue;
    }

    /// <inheritdoc />
    public override void receiveLeftClick(int x, int y)
    {
        if (this.greyedOut)
            return;

        base.receiveLeftClick(x, y);
        this.IsChecked = !this.IsChecked;
        this.SetValue(this.IsChecked);

        Game1.playSound(this.IsChecked ? "drumkit6" : "breathin");
    }

    /// <inheritdoc />
    public override void draw(SpriteBatch spriteBatch, int slotX, int slotY, IClickableMenu? context = null)
    {
        spriteBatch.Draw(Game1.mouseCursors, new Vector2(slotX + this.bounds.X, slotY + this.bounds.Y), this.IsChecked ? OptionsCheckbox.sourceRectChecked : OptionsCheckbox.sourceRectUnchecked, Color.White * (this.greyedOut ? 0.33f : 1f), 0.0f, Vector2.Zero, Game1.pixelZoom, SpriteEffects.None, 0.4f);
        base.draw(spriteBatch, slotX + this.GetOffsetX(), slotY, context);
    }
}
