﻿/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityManager.Resources;

namespace Thinktecture.IdentityManager
{
    public class PropertyMetadata
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public PropertyDataType DataType { get; set; }
        public bool Required { get; set; }

        internal void Validate()
        {
            if (String.IsNullOrWhiteSpace(Type)) throw new InvalidOperationException("PropertyMetadata Type is not assigned");
            if (String.IsNullOrWhiteSpace(Name)) throw new InvalidOperationException("PropertyMetadata Name is not assigned");
        }
    }
}