/*Prompt: update cells when the cell they are referencing changes*/

/*
To update cells in your spreadsheet application when the cells they are referencing change, you can implement a mechanism to handle cell dependencies.
One way to achieve this is by implementing a dependency graph where cells are nodes,
and edges represent dependencies between cells. Here's how you can modify your code to accomplish this:

Modify Cell Class in SpreadsheetEngine:
Firstly, you need to modify the Cell class in the SpreadsheetEngine namespace to include a list of dependent cells.
Each cell will keep track of the cells that depend on its value.*/

namespace SpreadsheetEngine
{
    public class Cell : INotifyPropertyChanged
    {
        private string text;
        private double value;
        private List<Cell> dependents;

        // Constructor, properties, methods, and PropertyChanged event implementation...

        public void AddDependent(Cell dependentCell)
        {
            if (!dependents.Contains(dependentCell))
            {
                dependents.Add(dependentCell);
            }
        }

        public void RemoveDependent(Cell dependentCell)
        {
            dependents.Remove(dependentCell);
        }

        // Rest of the Cell class implementation...
    }
}

/*
Update Form1 Class:
In the Form1 class, modify the event handler for cell end edit operation (DataGridView1_CellEndEdit). 
When a cell's text is changed, update the cell's text in the Spreadsheet object and notify all its dependent cells about the change.
*/

private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
{
    if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
    {
        var editedCell = this.spreadsheet.GetCell(e.ColumnIndex, e.RowIndex);
        editedCell.Text = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        // Notify dependents about the change
        foreach (var dependentCell in editedCell.Dependents)
        {
            dependentCell.Evaluate();
        }

        // Update the DataGridView cell value
        this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = editedCell.Value;
    }
}

/*
Modify Cell Evaluation Logic:
Ensure that your Cell class has an Evaluate method that calculates the cell's value based on its formula.
    This method should handle dependencies and update the cell's value accordingly.
*/

public void Evaluate()
{
    // Implement your evaluation logic here, considering dependencies.
    // Update the 'value' property of the cell based on the formula and dependent cells' values.
    // Notify PropertyChanged event if the value changes.
}

/*
In this setup, the AddDependent method in the Cell class allows a cell to register another cell as its dependent.
When a cell's value changes (due to a formula evaluation or user input), it notifies all its dependents to reevaluate.
This recursive reevaluation ensures that all dependent cells are updated when a referenced cell changes.

Please make sure to implement the Evaluate method in your Cell class to handle the actual logic of
evaluating cell formulas and updating cell values based on dependencies.
*/