// <copyright file="Spreadsheet.cs" company="Marco Arceo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// The spreadsheet class in charge of the majority of the program
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Creates a 2D array used for the spreadsheet
        /// </summary>
        public Cell[,] SpreadsheetCells;

        /// <summary>
        /// Keeps track of the dependencies between cells
        /// </summary>
        private Dictionary<string, List<string>> cellDependencies;

        /// <summary>
        /// Keeps track of the row count
        /// </summary>
        private int rowCount = 0;

        /// <summary>
        /// Keeps track of the column count
        /// </summary>
        private int columnCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// The constructor for the spreadsheet
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events
        /// </summary>
        /// <param name="rowNum">A placeholder for row count to assign</param>
        /// <param name="colNum">A placeholder for column count to assign</param>
        public Spreadsheet(int rowNum, int colNum)
        {
            this.cellDependencies = new Dictionary<string, List<string>>();
            this.SpreadsheetCells = new ReferenceCell[rowNum, colNum];
            this.PopulateSpreadSheet(rowNum, colNum);
        }

        /// <summary>
        /// Populates the spreadsheet with the rows and columns
        /// </summary>
        /// <param name="rowNum">The amount of rows in the spreadsheet</param>
        /// <param name="colNum">The amount of columns in the spreadsheet</param>
        public void PopulateSpreadSheet(int rowNum, int colNum)
        {
            for (int rowIndex = 0; rowIndex < rowNum; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colNum; colIndex++)
                {
                    this.SpreadsheetCells[rowIndex, colIndex] = new ReferenceCell(rowIndex, colIndex);
                    this.SpreadsheetCells[rowIndex, colIndex].PropertyChanged += this.EvaluateCell;
                }
            }
        }

        /// <summary>
        /// Returns the cell being looked at
        /// </summary>
        /// <param name="rowNum">The row number at which the cell is located</param>
        /// <param name="colNum">The column number at which the cell is located</param>
        /// <returns>
        /// The cell contained at that location
        /// </returns>
        public Cell GetCell(int rowNum, int colNum)
        {
            if (rowNum < 0 || colNum < 0 || rowNum > 50 || colNum > 26)
            {
                return null;
            }
            else if (this.SpreadsheetCells[rowNum, colNum] == null)
            {
                return null;
            }
            else
            {
                return this.SpreadsheetCells[rowNum, colNum];
            }
        }

        /// <summary>
        /// Gets gets or sets the row count
        /// </summary>
        public int RowCount => this.rowCount;

        /// <summary>
        /// Gets gets or sets the column count
        /// </summary>
        public int ColumnCount => this.columnCount;

        /// <summary>
        /// Use the parameter that raised the event and Evaluate the cell
        /// https://stackoverflow.com/questions/14479143/what-is-the-use-of-object-sender-and-eventargs-e-parameters
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events
        /// </summary>
        /// <param name="sender">Raises the event</param>
        /// <param name="e">The object in question</param>
        public void EvaluateCell(object sender, PropertyChangedEventArgs e)
        {
            if (sender is ReferenceCell currentCell && currentCell != null)
            {
                int index = 0;
                char currentCellColumn = Convert.ToChar(currentCell.ColumnIndex + 65);
                int currentCellRow = currentCell.RowIndex + 1;

                // Got help in the FIZ to remove dependencies from 355 TA that already took the class
                foreach (List<string> value in this.cellDependencies.Values)
                {
                    if (value.Contains(currentCellColumn.ToString() + currentCellRow.ToString()))
                    {
                        value.Remove(currentCellColumn.ToString() + currentCellRow.ToString());
                    }
                }

                if (currentCell.Text != null)
                {
                    if (currentCell.Text[index] != '=' || currentCell.Text == "")
                    {
                        currentCell.SetValue(currentCell.Text);
                        this.OnPropertyChanged("Text");
                        this.OnPropertyChanged("BGColor");
                        if (this.CellPropertyChanged != null)
                        {
                            this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Text"));
                            this.CellPropertyChanged(sender, new PropertyChangedEventArgs("BGColor"));
                        }
                    }
                    else if (currentCell.Text[index] == '=')
                    {
                        ExpressionTree tree = new ExpressionTree(currentCell.Text.Substring(1));
                        tree.Evaluate();
                        string[] variableNames = tree.GetVariableNames();

                        foreach (string currentVar in variableNames)
                        {
                            Cell newCell;

                            // Gets rid of the invalid input error
                            try
                            {
                                newCell = this.GetCell(Convert.ToInt32(currentVar.Substring(1)) - 1, currentVar[0] - 'A');
                            }
                            catch
                            {
                                newCell = null;
                            }

                            if (this.BadReferenceCheck(newCell))
                            {
                                currentCell.SetValue("!(Bad Reference)");
                                this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value"));
                                return;
                            }

                            if (newCell.Value != null && !newCell.Value.Contains(" "))
                            {
                                tree.SetVariable(currentVar, Convert.ToDouble(newCell.Value));
                            }
                            else
                            {
                                tree.SetVariable(currentVar, 0.0);
                            }

                            if (this.SelfReferenceCheck(currentCellColumn.ToString() + currentCellRow.ToString(), currentVar))
                            {
                                currentCell.SetValue("!(Self Reference)");
                                this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value"));
                                return;
                            }

                            if (this.cellDependencies.ContainsKey(currentVar))
                            {
                                this.cellDependencies[currentVar].Add(currentCellColumn.ToString() + currentCellRow.ToString());
                            }
                            else
                            {
                                this.cellDependencies[currentVar] = new List<string>();
                                this.cellDependencies[currentVar].Add(currentCellColumn.ToString() + currentCellRow.ToString());
                            }
                        }

                        currentCell.SetValue(tree.Evaluate().ToString());
                        this.OnPropertyChanged("Value");
                        this.OnPropertyChanged("BGColor");
                        if (this.CellPropertyChanged != null)
                        {
                            this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value"));
                            this.CellPropertyChanged(sender, new PropertyChangedEventArgs("BGColor"));
                        }
                    }
                }
                else
                {
                    currentCell.SetValue(null);
                    currentCell.Text = null;
                    this.OnPropertyChanged("Value");
                    this.OnPropertyChanged("Text");
                    this.OnPropertyChanged("BGColor");
                    if (this.CellPropertyChanged != null)
                    {
                        this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value"));
                        this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Text"));
                        this.CellPropertyChanged(sender, new PropertyChangedEventArgs("BGColor"));
                    }
                }

                // https://stackoverflow.com/questions/15241257/using-a-for-loop-to-iterate-through-a-dictionary
                // Had enumerate issues, converting to an array fixed it
                if (this.cellDependencies.ContainsKey(currentCellColumn.ToString() + currentCellRow.ToString()))
                {
                    foreach (string cell in this.cellDependencies[currentCellColumn.ToString() + currentCellRow.ToString()].ToArray())
                    {
                        Cell updateCell = this.GetCell(Convert.ToInt32(cell.Substring(1)) - 1, cell[0] - 'A');
                        this.EvaluateCell(updateCell, e);
                    }
                }
            }
        }

        /// <summary>
        /// Checks that the cell was modified before
        /// </summary>
        /// <param name="checkCell">The cell being checked</param>
        /// <returns>True or False</returns>
        public bool DefaultPropertyCheck(Cell checkCell)
        {
            bool modifiedCell = true;
            if (checkCell.Text != null || checkCell.Value != null || checkCell.BGColor != 4294967295)
            {
                modifiedCell = false;
            }
            else
            {
                modifiedCell = true;
            }

            return modifiedCell;
        }

        /// <summary>
        /// Creates the XML file to be saved
        /// https://stackoverflow.com/questions/1123718/format-xml-string-to-print-friendly-xml-string
        /// </summary>
        /// <param name="file">The outfile to which the XML saves to</param>
        public void SaveXML(Stream file)
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            XmlWriter saveXML = XmlWriter.Create(file, settings);
            saveXML.WriteStartElement("spreadsheet");
            foreach (Cell curCell in this.SpreadsheetCells)
            {
                if (this.DefaultPropertyCheck(curCell) == false)
                {
                    char currentCellColumn = Convert.ToChar(curCell.ColumnIndex + 65);
                    int currentCellRow = curCell.RowIndex + 1;
                    string name = currentCellColumn.ToString() + currentCellRow.ToString();
                    saveXML.WriteStartElement("cell");
                    saveXML.WriteAttributeString("name", name);
                    saveXML.WriteElementString("bgcolor", curCell.BGColor.ToString("X6"));
                    if (curCell.Text != null)
                    {
                        saveXML.WriteElementString("text", curCell.Text.ToString());
                    }
                }
            }

            saveXML.WriteEndElement();
            saveXML.Close();
        }

        /// <summary>
        /// Loads an XML file into the spreadsheet
        /// </summary>
        /// <param name="file">The file to save to</param>
        public void LoadXML(Stream file)
        {
            using (XmlReader xmlLoad = XmlReader.Create(file))
            {
                xmlLoad.ReadToFollowing("cell");
                while (xmlLoad.NodeType != System.Xml.XmlNodeType.EndElement)
                {
                    xmlLoad.MoveToAttribute("name");
                    string name = xmlLoad.GetAttribute("name");
                    if (name != null)
                    {
                        Cell currentCell = this.GetCell(Convert.ToInt32(name.Substring(1)) - 1, name[0] - 'A');
                        while (xmlLoad.Read())
                        {
                            if (xmlLoad.Name == "cell")
                            {
                                break;
                            }
                            else
                            {
                                if (xmlLoad.NodeType == XmlNodeType.Element)
                                {
                                    switch (xmlLoad.Name.ToString())
                                    {
                                        case "text":
                                            xmlLoad.Read();
                                            currentCell.Text = xmlLoad.Value.ToString();
                                            break;

                                        case "bgcolor":
                                            xmlLoad.Read();
                                            currentCell.BGColor = (uint)int.Parse(xmlLoad.Value.ToString(), System.Globalization.NumberStyles.HexNumber);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clears the spreadsheet for loading an XML file
        /// </summary>
        /// <param name="rowNum">The number of rows</param>
        /// <param name="colNum">The number of columns</param>
        public void ClearSpreadSheet(int rowNum, int colNum)
        {
            for (int rowIndex = 0; rowIndex < rowNum; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colNum; colIndex++)
                {
                    this.SpreadsheetCells[rowIndex, colIndex].Text = null;
                    this.SpreadsheetCells[rowIndex, colIndex].BGColor = 4294967295;
                }
            }
        }

        /// <summary>
        /// Checks for self reference
        /// </summary>
        /// <param name="cellName">current cell</param>
        /// <param name="cellText">current variable</param>
        /// <returns>true or false</returns>
        public bool SelfReferenceCheck(string cellName, string cellText)
        {
            bool selfReference = false;

            if (cellName == cellText)
            {
                selfReference = true;
            }

            return selfReference;
        }

        /// <summary>
        /// Checks for bad references
        /// </summary>
        /// <param name="checkCell">the cell to check</param>
        /// <returns>true or false</returns>
        public bool BadReferenceCheck(Cell checkCell)
        {
            bool badReference = false;

            if (checkCell == null)
            {
                badReference = true;
            }

            return badReference;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/34440667/unable-to-create-instance-of-abstract-class-in-interface-method
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
        /// https://stackoverflow.com/questions/30696006/inheritance-with-base-class-constructor-with-parameters
        /// https://stackoverflow.com/questions/6037546/assigning-a-value-to-an-inherited-readonly-field
        /// </summary>
        private class ReferenceCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ReferenceCell"/> class.
            /// Constructs the reference cell
            /// </summary>
            /// <param name="rowNum">number of rows</param>
            /// <param name="colNum">number of columns</param>
            public ReferenceCell(int rowNum, int colNum)
                : base(rowNum, colNum)
            {
            }

            /// <summary>
            /// Sets a string to the value
            /// </summary>
            /// <param name="newValue">A new string value</param>
            public void SetValue(string newValue)
            {
                this.value = newValue;
            }
        }

        /// <summary>
        /// Creates a Property Changed Event Handler to keep track of any changes in the spreadsheet
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Followed the MSDN documentation for implementing this function
        /// https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification
        /// </summary>
        /// <param name="name">Acts as the string for the change</param>
        protected void OnPropertyChanged(string name)
        {
            this.CellPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}