
#region Notes on Object-Oriented Programming
/*
 * In object-oriented programming, classes are the "blueprints" or "templates" for making objects.
 * Just as a cookie-cutter can be used to make any number of cookies, a class can be used to make any
 * number of objects. In Microsoft Visual Studio, objects have properties (variables) and methods 
 * (procedures/functions). Special objects called "controls" also have events.
 * 
 * property-> A variable that belongs to an object, typically used to store
 *            information about a characteristic of the object
 * method  -> A procedure or function that belongs to an object. Methods are
 *            ACTIONS that can be performed by, to or for an object.
 * event   -> An event is a message sent by an object to signal the occurrence 
 *            of an action. Events are used to trigger the execution of code.
 * 
 * For example, the "Button" class is used to make buttons in Windows Forms applications. 
 * 
 * Text    -> A property found within the Button class. It stores the text that is displayed on the button.
 * Hide    -> A method found within the Button class. It is used to hide a button.
 * Click   -> An event found within the Button class. The "Click" event is "raised" ("fired")
 *            whenever the user clicks on a button.
 */

/*
    * OBJECT-ORIENTED PROGRAMMING (OOP) -> MORE DETAILS
    * 
    * CLASSES and OBJECTS: Classes are "templates" or "blueprints" for "making" objects. They ENCAPSULATE 
    * (see below) data and the methods (procedures) that operate on the data. When a class is used to 
    * "make" an object, the object is called an "instance" of the class.
    * 
    * Analogy: Class = Cookie Cutter    Object/Instance of the Class = Cookie
    * 
    * Objects often represent tangible things like buttons or text boxes but they can also represent more
    * abstract entities such as geometric shapes. Classes contain both DATA MEMBERS and FUNCTION MEMBERS.
    * 
    * 1. DATA MEMBERS -> Variables or objects that belong to a class or an instance of the class
    * 
    *    (a) Data members store information about the STATE of an object.
    *    
    *    (b) In C#, the data members are called FIELDS. In Java, the data members are called DATA FIELDS.
    *        
    *    (b) Because of the OOP principle of ABSTRACTION (see below), fields in C# are usually declared as
    *        "private." Abstraction is achieved when each object keeps its state private. Other objects 
    *        don’t have direct access to this state. Instead, they can only access the data members that  
    *        are EXPOSED to other objects.
    *                
    *        C# -> Fields can be exposed to other objects through PROPERTIES. (e.g. "Text" property)
    *        Java -> Data fields are exposed to other objects only through calls of public methods
    *                called "getters" and "setters." (e.g. getText(), setText())
    *                
    * 2. PROCEDURE/FUNCTION MEMBERS -> Procedures/functions that belong to a class or an instance of the class
    *    
    *    (a) Procedure/function members are used to INQUIRE ABOUT or CHANGE THE STATE of an object.
    *    
    *    (b) Across most object-oriented languages, such procedures/functions are called METHODS.
    *    
    *    (c) Methods can be OVERLOADED. This means that multiple methods can have the same name as 
    *        long as their parameters differ in either number or type.
    * 
    * 3. CONSTRUCTOR METHODS (CONSTRUCTORS) -> Special methods that are called to initialize a newly
    *    created object. The name of a constructor method is always the same as the name of the class.
    *    
    * 4. INNER CLASSES -> Classes can be defined WITHIN classes.
    *                                          
    * The four basic principles of OOP are ENCAPSULATION, ABSTRACTION, INHERITANCE, and POLYMORPHISM.
    * 
    * ENCAPSULATION
    * Encapsulation means that data, and the methods that operate on the data, are BUNDLED within a single unit.
    * e.g. a class bundles data in the form of variables and objects (called "fields" collectively in C#
    * and "data fields" in Java) with the methods that operate on these variables and objects.
    *                     
    * ABSTRACTION
    * Reduce complexity by hiding details from the user (of a class for example). Users only need to know
    * which methods are available and how to call them. The implementation of the methods is HIDDEN!
    *              
    * INHERITANCE
    * New classes/structures can be built from existing classes/structures. When a class is built upon an
    * existing class, it inherits all its members. For example, the class "MathematicalFunctionsSortingForm"
    * is built upon the existing .NET class called "Form". "MathematicalFunctionsSortingForm" INHERITS
    * all members of the "Form" class and also has members of its own. "MathematicalFunctionsSortingForm"
    * is called the SUBCLASS and "Form" is called the SUPERCLASS.
    *              
    * POLYMORPHISM
    * From Greek: Poly = many, Morph = change or form
    * In OOP, "polymorphism" refers to the ability to present the SAME INTERFACE for DIFFERENT UNDERLYING
    * FORMS (e.g. data types).
    * e.g. The mathematical operators +, -, *, / and % work with ANY numeric data type. The data types can
    *      be different (e.g. int and double) but the interface for working with them (in this case the 
    *      operators) is the same.
    * e.g. Create a class (superclass) called "Shape" that serves as the foundation for subclasses such
    *      as "Square", "Circle", "Polygon", etc. Although each shape is diffrent in some way, the "Draw" 
    *      operation is the same. Each subclass implements its own "Draw" method because the details of
    *      drawing differ from one shape to another but the NAME of the method is the same!
    */

#endregion

#region Explanation of Namespaces and Using Directives

/*
 * IMPORTANT NOTE ON NAMESPACES and USING DIRECTIVES
 * 
 * The .NET framework provides a large number of classes for developing Windows Forms Applications.
 * While this affords application developers a vast array of built-in functionality, it can lead to 
 * an organizational nightmare. To address this issue, namespaces and using directives were introduced.
 * They greatly help to simplify and organize code.
 * 
 * Namespaces: It is generally a good practice to use a single namespace for a C# application. This 
 * allows for greater internal and external organization. ("External organization" refers to
 * the means by which programming elements are presented to other applications.)
 * 
 * You will notice that all C# applications consist of code that is "spread" across multiple files.
 * For example, the C# code for this application is spread across the following files:
 * 
 * Program.cs (the main entry point of the application -> this is where execution begins)
 * MathematicalFunctionsSortingForm.cs (the code you write for the form, including event handlers)
 * MathematicalFunctionsSortingForm.Designer.cs (code that is automatically generated by the designer)
 * MathFunctions.cs, SortingMethods.cs (used to store various methods in an organized way)
 * 
 * When all these files are within the same namespace, naming is simplified because the namespace 
 * does not need to be specified.
 * 
 * "Using" directives make it possible to use classes and other structures that are found within different
 * namespaces without specifying the full path name. For example, without "Using System.Windows.Forms",
 * it would be necessary to write "System.Windows.Forms.MessageBox.Show("Blah, blah, blah!");". With 
 * the using directive, this is not necessary. One can simply write "MessageBox.Show("Blah, blah, blah!");".
 * 
 * Note that in "System.Windows.Forms", "Forms" is a namespace within "Windows" which is yet 
 * another namespace within "System".
 */

/*
 * For more information on "namespaces" and "using directives", see
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/namespaces
 * Within this document, scroll down to ...
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/namespaces#using-directives
 * for more information on using directives.
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// Icon used for this application credited to:
// Icons made by "smalllikeart" (https://www.flaticon.com/authors/smalllikeart)
// From "Flaticon" (https://www.flaticon.com/)		    
// Licensed by "Creative Commons BY 3.0" (http://creativecommons.org/licenses/by/3.0/)		

namespace MathematicalFunctionsSearchingSorting
{
    public partial class MathematicalFunctionsForm : Form
    {
        // All your code should be placed within the class.

        #region Examples of Comments

        // This is a one-line comment

        /*
         * 
         * This is a multi-line comment.
         * 
         */

        /// <summary>
        /// This is an XML comment. The purpose of XML comments will be discussed in class.
        /// </summary>

        /* Comments SHOULD NOT be used to explain code that is self-explanatory.
         * 
         * As much as possible, code should be written in such a way that is self-explanatory.
         * 
         * Comments SHOULD be used to explain complex algorithms and techniques.
         * Comments should be short and to the point
         * As a rule of thumb, it is better to explain WHY instead of HOW.
         */

        #endregion

        #region Global Declarations, Initializations and Instantiations
        // Global variables and objects should be created at the top of the class.
        // If a variable or object is global to a class, any procedure in the class
        // can access and modify it.

        // Declaration: Associates a name with a data type or class
        // Initialization: Gives a variable its initial value
        // Instantiation: Creates an object and initializes it

        bool textSelected = false;

        /*
         * The part of the following statement that lies to the left of the equals sign 
         * associates the name "numberList" with a list of "double" values. This is called 
         * a "declaration." The part that lies on the right creates the initially empty list. 
         * This is called an "instantiation."
         */
        private List<double> numberList = new List<double>();

        #endregion

        #region Constructor Method

        // The following is called a "constructor method" for the class "MathematicalFunctionsForm".
        // In general, constructor methods are called whenever a new object is created. 
        // The purpose of a constructor method is to initialize an object.

        // Place within the constructor method for a form (after the call to "InitializeComponent") 
        // any code that needs to be executed as soon as the form is created (i.e. loaded).
        // DO NOT DELETE the call to "InitializeComponent." If you do, you'll definitely notice
        // that something is wrong once you run the program!

        public MathematicalFunctionsForm()
        {
            // Do not delete this call! See above comment!
            InitializeComponent();

            // The "DropDownStyle" property of combo boxes has been changed to
            // "DropDownList" to prevent the user from editing text in the ComboBox. Because of 
            // this change, the "Text" property cannot be set using the designer. Therefore, it
            // is set here in the constructor method.
            SortingMethodComboBox.Text = "Selection Sort";
            PartitionMethodComboBox.Text = "Naive Partition";

            // The menu item "Project...MathematicalFunctionsSorting Properties" displays a series
            // of pages of various properties of the project. On the "Application" page, an icon
            // can be loaded to replace the default icon. The following statement sets the icon
            // for this form object by extracting it from the application's executable path.

            // Notice that the full path name to the "Icon" class is specified because there is
            // no "using" directive to include the "System.Drawing" namespace.
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        #endregion

        #region Event Handlers

        // "Event handlers" (event-handling procedures) are not called explicitly by your code.
        // They are called automatically whenever the specified event occurs. This is done by the 
        // event-listener loop, which runs "behind the scenes" in the .NET framework runtime environment.

        #region Entering, Displaying and Clearing Data

        private void ClearButton_Click(object sender, EventArgs e)
        {
            numberList.Clear();
            NumberListBox.Items.Clear();
            IndexListBox.Items.Clear();
            NumberListBox.SelectedIndex = -1; //Remove any highlighting
            IndexListBox.SelectedIndex = -1; //Remove any highlighting
            NumberTextBox.Text = "";
            outputLabel.Text = "";
            LeftTextBox.Text = "0";
            RightTextBox.Text = "0";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // The "TryParse" method defined within the "Double" structure (similar to a class but "weaker")
            // tries to convert a given string to a "double" value. If it succeeds, it returns "true" and it 
            // assigns the converted value to the specified "out" variable. Otherwise, it returns "false". 

            // "bool" data type: stands for "Boolean", only two values, "true" and "false"
            // This data type is named after George Boole, a 19th century British mathematician, logician 
            // and philosopher who among many other things, developed the mathematical system of logic
            // now called Boolean Algebra. This system of logic forms the foundation of digital circuits.
            bool isNumeric = Double.TryParse(NumberTextBox.Text, out double number);

            NumberListBox.SelectedIndex = -1; //Remove any highlighting

            if (isNumeric) // This is equivalent to 'if (isNumeric == true)'
            {
                // Add the entered number to both the list and the list box
                numberList.Add(number);
                NumberListBox.Items.Add(number);

                // Update 'IndexListBox'
                string highestIndex = (numberList.Count - 1).ToString();
                IndexListBox.Items.Add(highestIndex);

                // Update text boxes for partition limits
                LeftTextBox.Text = "0";
                RightTextBox.Text = highestIndex;

            }
            else
            {
                MessageBox.Show("You may only enter numbers.", "Numeric Value Required");
            }

            // To make data easier to enter, select the text in the text box. Also give the focus to the 
            // text box. Otherwise, the button will have the focus.
            NumberTextBox.SelectAll();
            textSelected = true;
            NumberTextBox.Focus();
        }

        // To make entering data easier, select (highlight) the text in the text box 
        // whenever the text box is activated (i.e. whenever the "Enter" event occurs).
        // See https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.enter?view=netframework-4.7.2. )

        private void NumberTextBox_Enter(object sender, EventArgs e)
        {
            NumberTextBox.SelectAll();
            textSelected = true;
            NumberTextBox.Focus();
        }

        private void NumberTextBox_Click(object sender, EventArgs e)
        {
            if (textSelected)
            {
                // "Unselect" the text
                NumberTextBox.SelectionLength = 0;
                textSelected = false;
            }
            else
            {
                NumberTextBox.SelectAll();
                textSelected = true;
            }

        }

        private void FillListBoxWithRandomValuesButton_Click(object sender, EventArgs e)
        {
            // This statement is called a "class instantiation", which means that it creates an 
            // "instance of a class" (otherwise known as an "object".)
            // "Random" -> name of the class
            // "randomNumberGenerator" -> name of the object
            // "new" -> create new object
            // "Random()" -> call of constructor method
            Random randomNumberGenerator = new Random();

            bool isNumeric = Int32.TryParse(HowManyRandomValuesTextBox.Text, out int howMany);

            if (isNumeric)
            {
                numberList.Clear();

                // Fill 'numberList' with pseudorandom double values between -500 and 500,
                // rounded to three decimal places.
                for (int i = 1; i <= howMany; i++)
                {
                    double number = Math.Round(randomNumberGenerator.NextDouble() * 1001 - 500, 3);
                    numberList.Add(number);
                }

                // Display pseudorandom numbers and associated indices in the list boxes
                DisplayResultsAndPrepareForNextInputValue();

                RightTextBox.Text = (howMany - 1).ToString();
            }
            else
            {
                MessageBox.Show("You may only enter positive whole numbers.", "Numeric Value Required");
            }
        }

        #endregion

        #region Searching, Sorting, Scrambling

        private void LinearSearchButton_Click(object sender, EventArgs e)
        {
            bool isNumericValue = Double.TryParse(NumberTextBox.Text, out double number);

            if (isNumericValue)
            {
                int foundAtIndex = Searching.LinearSearch(numberList, number);

                if (foundAtIndex >= 0)
                {
                    outputLabel.Text = "The key '" + number.ToString() + "' was found at index '" + foundAtIndex.ToString() + "'.";
                    NumberListBox.SelectedIndex = foundAtIndex;
                    IndexListBox.SelectedIndex = foundAtIndex;
                }
                else
                {
                    outputLabel.Text = "The key '" + number.ToString() + "' was not found.";
                    NumberListBox.SelectedIndex = -1;
                    IndexListBox.SelectedIndex = -1;
                }
            }
        }

        private void BinarySearchButton_Click(object sender, EventArgs e)
        {
            bool isNumericValue = Double.TryParse(NumberTextBox.Text, out double number);

            if (isNumericValue)
            {
                int foundAtIndex = Searching.BinarySearch(numberList, number);

                if (foundAtIndex >= 0)
                {
                    outputLabel.Text = "The key '" + number.ToString() + "' was found at index '" + foundAtIndex.ToString() + "'.";
                    NumberListBox.SelectedIndex = foundAtIndex;
                    IndexListBox.SelectedIndex = foundAtIndex;
                }
                else
                {
                    outputLabel.Text = "The key '" + number.ToString() + "' was not found.";
                    NumberListBox.SelectedIndex = -1;
                    IndexListBox.SelectedIndex = -1;
                }
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {

            if (SortingMethodComboBox.Text == "Selection Sort")
            {
                Sorting.SelectionSort(numberList);
            }
            else if (SortingMethodComboBox.Text == "Bubble Sort")
            {
                Sorting.BubbleSort(numberList);
            }
            else if (SortingMethodComboBox.Text == "Cocktail Sort")
            {
                Sorting.CocktailSort(numberList);
            }
            else if (SortingMethodComboBox.Text == "Insertion Sort")
            {
                Sorting.InsertionSort(numberList);
            }
            else if (SortingMethodComboBox.Text == "Shell Sort")
            {
                Sorting.ShellSort(numberList);
            }
            else if (SortingMethodComboBox.Text == "Quick Sort")
            {
                Sorting.QuickSort(numberList, 0, numberList.Count - 1);
            }

            // Display sorted list and associated indices in the list boxes
            DisplayResultsAndPrepareForNextInputValue();
        }

        private void PartitionButton_Click(object sender, EventArgs e)
        {
            bool isNumericLeft = Int32.TryParse(LeftTextBox.Text, out int left);
            bool isNumericRight = Int32.TryParse(RightTextBox.Text, out int right);

            if (isNumericLeft && isNumericRight && left >= 0 && right < numberList.Count)
            {
                int pivotIndex = -1;

                if (PartitionMethodComboBox.Text == "Naive Partition")
                {
                    pivotIndex = Sorting.NaivePartition(numberList, left, right);
                }
                else if (PartitionMethodComboBox.Text == "Lomuto Partition")
                {
                    pivotIndex = Sorting.LomutoPartition(numberList, left, right);
                }
                else if (PartitionMethodComboBox.Text == "Hoare Partition")
                {
                    pivotIndex = Sorting.HoarePartition(numberList, left, right);
                }

                // Display partitioned list and highlight pivot and pivot index
                DisplayResultsAndPrepareForNextInputValue();

                NumberListBox.SelectedIndex = pivotIndex;
                IndexListBox.SelectedIndex = pivotIndex;
            }
            else
            {
                MessageBox.Show("Check your values to ensure that they are valid.");
            }

        }

        private void ScrambleButton_Click(object sender, EventArgs e)
        {
            Sorting.Scramble(numberList);

            // Display scrambled list and associated indices in the list boxes
            DisplayResultsAndPrepareForNextInputValue();
        }

        #endregion

        #region Mathematical Calculations

        private void MinButton_Click(object sender, EventArgs e)
        {
            int minIndex = MathFunctions.IndexOfMinimum(numberList);

            NumberListBox.SelectedIndex = -1; //Remove any highlighting

            if (minIndex >= 0)
            {
                outputLabel.Text = "The minimum value is " + numberList[minIndex].ToString() + ".";
                NumberListBox.SelectedIndex = minIndex;
                IndexListBox.SelectedIndex = minIndex;
            }
            else
            {
                outputLabel.Text = "The list is empty.";
            }

            NumberTextBox.SelectAll();
            textSelected = true;
        }

        private void MaxButton_Click(object sender, EventArgs e)
        {
            int maxIndex = MathFunctions.IndexOfMaximum(numberList);

            NumberListBox.SelectedIndex = -1; //Remove any highlighting

            if (maxIndex >= 0)
            {
                outputLabel.Text = "The maximum value is " + numberList[maxIndex].ToString() + ".";
                NumberListBox.SelectedIndex = maxIndex;
                IndexListBox.SelectedIndex = maxIndex;
            }
            else
            {
                outputLabel.Text = "The list is empty.";
            }

            NumberTextBox.SelectAll();
            textSelected = true;
        }

        private void RoundButton_Click(object sender, EventArgs e)
        {
            bool isNumericValue = Double.TryParse(NumberTextBox.Text, out double number);
            bool isNumericDecimalPlaces = Int32.TryParse(DecimalPlacesTextBox.Text, out int decPlaces);

            if (isNumericValue && isNumericDecimalPlaces)
            {
                string format = (decPlaces > 0) ? "{0:0." + new String('0', decPlaces) + "}" : "{0:0.}";
                string rounded = String.Format(format, MathFunctions.RoundOff(number, decPlaces));

                outputLabel.Text = rounded;
                NumberTextBox.Text = rounded;
            }
            else
            {
                MessageBox.Show("Check your values to ensure that they are numeric.");
            }

        }

        private void AverageButton_Click(object sender, EventArgs e)
        {
            double average = MathFunctions.ArithmeticMean(numberList);

            //Check for valid returned value
            if (!Double.IsNaN(average))
            {
                outputLabel.Text = "The arithmetic mean is " + average.ToString() + ".";
            }
            else
            {
                outputLabel.Text = "The list is empty. Arithmetic mean cannot be calculated.";
            }
        }

        private void MedianButton_Click(object sender, EventArgs e)
        {
            double median = MathFunctions.Median(numberList);

            //Check for valid returned value
            if (!Double.IsNaN(median))
            {
                outputLabel.Text = "The median is " + median.ToString() + ".";
                DisplayResultsAndPrepareForNextInputValue();
            }
            else
            {
                outputLabel.Text = "The list is empty. Median cannot be calculated.";
            }
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            List<double> modes = MathFunctions.Mode(numberList);

            if (modes.Count > 0)
            {
                //Build a string consisting of all the modes
                string modeString = "";
                for (int i = 0; i < modes.Count; i++)
                {
                    modeString += modes[i] + ", ";
                }

                //Remove final comma and space
                modeString = modeString.Substring(0, modeString.Length - 2);

                outputLabel.Text = "The mode(s) is(are): " + modeString;
            }
            else
            {
                outputLabel.Text = "The mode of an empty list is undefined.";
            }

            //
        }

        private void GeometricMeanButton_Click(object sender, EventArgs e)
        {
            double geometricMean = MathFunctions.GeometricMean(numberList);

            //Check for valid returned value
            if (!Double.IsNaN(geometricMean))
            {
                outputLabel.Text = "The geometric mean is " + geometricMean.ToString() + ".";
            }
            else
            {
                // (char) 10 forces the integer '10' to be converted to a 'char'
                // The character with decimal code '10' in Unicode is called the "line feed" character.
                // It forces the text that follows it to be displayed on the next line.
                outputLabel.Text = "The list is empty or at least one value is nonpositive. " + (char)10 +
                                                                    "Geometric mean cannot be calculated.";
            }
        }

        private void HarmonicMean_Click(object sender, EventArgs e)
        {
            double harmonicMean = MathFunctions.HarmonicMean(numberList);

            //Check for valid returned value
            if (!Double.IsNaN(harmonicMean))
            {
                outputLabel.Text = "The harmonic mean is " + harmonicMean.ToString() + ".";
            }
            else
            {
                // (char) 10 forces the integer '10' to be converted to a 'char'
                // The character with decimal code '10' in Unicode is called the "line feed" character.
                // It forces the text that follows it to be displayed on the next line.
                outputLabel.Text = "The list is empty or at least one value is nonpositive. " + (char)10 +
                                                                    "Harmonic mean cannot be calculated.";
            }
        }

        private void KthSmallestButton_Click(object sender, EventArgs e)
        {
            bool isNumericValue = Int32.TryParse(kTextBox.Text, out int k);

            if (isNumericValue)
            {
                double kthSmallest = MathFunctions.QuickSelect(numberList, k, 0, numberList.Count - 1);

                NumberListBox.SelectedIndex = -1; //Remove any highlighting

                if (!Double.IsNaN(kthSmallest))
                {
                    string ordinal = "";

                    if (k > 3)
                    {
                        ordinal = k.ToString() + "th";
                    }
                    else if (k == 2)
                    {
                        ordinal = k.ToString() + "nd";
                    }
                    
                    outputLabel.Text = "The " + ordinal + " smallest value is " + kthSmallest.ToString() + ".";

                    DisplayResultsAndPrepareForNextInputValue();
                    NumberListBox.SelectedIndex = k-1;
                    IndexListBox.SelectedIndex = k-1;
                }
                else
                {
                    outputLabel.Text = "The list is empty or the value of 'k' is invalid.";
                    NumberTextBox.SelectAll();
                    textSelected = true;
                }
            }
        }

        #endregion

        #endregion

        #region Miscellaneous
        
        // Event handlers that ensure that the selected values in the list boxes have the same index
        private void IndexListBox_Click(object sender, EventArgs e)
        {
            NumberListBox.SelectedIndex = IndexListBox.SelectedIndex;
        }

        private void NumberListBox_Click(object sender, EventArgs e)
        {
            IndexListBox.SelectedIndex = NumberListBox.SelectedIndex;
        }

        #endregion

        // Helper method to avoid repetitive code in many of the event handlers
        private void DisplayResultsAndPrepareForNextInputValue()
        {
            NumberListBox.Items.Clear();
            IndexListBox.Items.Clear();

            for (int i = 0; i < numberList.Count; i++)
            {
                NumberListBox.Items.Add(numberList[i].ToString());
                IndexListBox.Items.Add(i.ToString());
            }

            NumberTextBox.SelectAll();
            textSelected = true;
        }

    }// end of class

}// end of namespace
