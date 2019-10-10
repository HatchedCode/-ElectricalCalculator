// <copyright file="ICommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CalculatorEngine
{
    /// <summary>
    /// https://www.codeproject.com/Articles/33384/Multilevel-Undo-and-Redo-Implementation-in-Cshar-2
    /// Created the Interface for the command design pattern
    /// </summary>
    public interface ICommand
    {
        ICommand Execute();
    }
}
