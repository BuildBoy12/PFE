// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace PFE
{
    using Exiled.API.Features.Items;
    using Exiled.Events.EventArgs;
    using InventorySystem.Items.ThrowableProjectiles;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the plugin class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnDying(DyingEventArgs)"/>
        public void OnDying(DyingEventArgs ev)
        {
            if (!plugin.Config.AffectedRoles.Contains(ev.Target.Role.Type))
                return;

            ThrowableItem throwableItem = (ThrowableItem)ev.Target.Inventory.CreateItemInstance(ItemType.GrenadeHE, true);
            ExplosiveGrenade explosionGrenade = new ExplosiveGrenade(throwableItem) { FuseTime = plugin.Config.Delay };
            for (int i = 0; i < plugin.Config.Magnitude; i++)
            {
                explosionGrenade.SpawnActive(ev.Target.Position, ev.Target);
            }
        }
    }
}