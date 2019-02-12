//-----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Code Analysis suppression rules.</summary>
//-----------------------------------------------------------------------

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the
// Error List, point to "Suppress Message(s)", and click
// "In Project Suppression File".
// You do not need to add suppressions to this file manually.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "0", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#Useful.Security.Cryptography.IUsefulCryptoTransform.TransformBlock(System.Byte[],System.Int32,System.Int32,System.Byte[],System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "0", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#System.Security.Cryptography.ICryptoTransform.TransformBlock(System.Byte[],System.Int32,System.Int32,System.Byte[],System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "3", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#Useful.Security.Cryptography.IUsefulCryptoTransform.TransformBlock(System.Byte[],System.Int32,System.Int32,System.Byte[],System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "0", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#System.Security.Cryptography.ICryptoTransform.TransformFinalBlock(System.Byte[],System.Int32,System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "0", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#TransformBlock(System.Byte[],System.Int32,System.Int32,System.Byte[],System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "3", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#TransformBlock(System.Byte[],System.Int32,System.Int32,System.Byte[],System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "0", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#TransformFinalBlock(System.Byte[],System.Int32,System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Clashes with CodeContracts.", MessageId = "0", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticTransform.#TransformString(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Justification = "It's only a small project.", Scope = "namespace", Target = "Useful.Security.Cryptography")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Justification = "It's only a small project.", Scope = "namespace", Target = "Useful.Security.Cryptography")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Justification = "It's only a small project.", Scope = "namespace", Target = "Useful.Wpf.Converters")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "It's an acronym.", MessageId = "WPF", Scope = "namespace", Target = "Useful.WPF.Converters")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1043:UseIntegralOrStringArgumentForIndexers", Justification = "It's fine.", Scope = "member", Target = "Useful.Security.Cryptography.MonoAlphabeticSettingsObservableCollection.#Item[System.Char]")]