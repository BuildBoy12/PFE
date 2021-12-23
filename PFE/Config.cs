// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace PFE
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a collection of roles that should explode upon death.
        /// </summary>
        [Description("A collection of roles that should explode upon death.")]
        public RoleType[] AffectedRoles { get; set; } =
        {
            RoleType.Scp173,
        };

        /// <summary>
        /// Gets or sets the amount of grenades to spawn.
        /// </summary>
        [Description("The amount of grenades to spawn.")]
        public int Magnitude { get; set; } = 1;

        /// <summary>
        /// Gets or sets the amount of time, in seconds, between death and the explosion.
        /// </summary>
        [Description("The amount of time, in seconds, between death and the explosion.")]
        public float Delay { get; set; } = 0.15f;
    }
}