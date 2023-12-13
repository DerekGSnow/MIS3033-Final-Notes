# MIS3033-Final-Notes
Summarizing the notes of things learned in MIS 3033, Business Programming Languages

## Unit 1 

Unit 1 mainly focused on using WPF applications. This example doesn't include API calls, but the coursework consisted of loading in JSONs via API or a file and changing them in some way. 

This example uses a homework. It loads in a car csv file, serializes it with JSON, and puts it into a list box. It also has a combo box used to sort. 
Ensure Newtonsoft JSON is added! When adding an existing file **ensure that the file's property "Copy to Output Directory" is "Copy Always"** 

This course allowed the use of GPT as an aid to learning. With GPT, you want to specify as much information as possible. If it is wrong, correct it. If the code generates an error, work with it to fix it. 

Example GPT Search: 
```
You are a code-writing assistant. Respond to the prompt by writing code.

We are working in a C# WPF application. 
Create a c# class for this vin,make,color,year,model,sale_price
KMHGH4JH6DU355882,GMC,Blue,1994,2500 Club Coupe,$26137.46
```

and additionally, in the same conversation, 
```
We now need to read in the csv data and deseralize with json. Let's use newtonsoft json to do so. Let's have a List of all the cars.
```

## Unit 2

Unit 2 focused on using EF Power Core Tools in addition with ASP.Net Core MVC applications. 
MVC is split into Model, View, and Controller. Controllers, *also referred to as "actions"* decide which view should be shown and what information is passed to it for processing. It usually passes a Model to the View. 
Thus, if the URL is /University/States, University is the Controller, and States is the Controller. 

Using EF Power Core Tools and accessing a database mainly autogenerates, but there are still a lot of steps to do it to accomplish it. 

### EF Power Core Tools in MVC Steps

- Create the MVC Asp.Net Application *(ensure that HTTPS is OFF)*
- Right click the project, EF Core Power Tools, and Reverse Engineering
	- Process depends on the Database
- Go to the context and the new Model that was made. Make sure "Integrated Security=False;TrustServerCertificate=True" has been added to the string.
- We need to add a controller. Right click the project, add controller, with the full MVC kit
- Select the Database Context, then select the Model you'd like to make a controller for. **Ensure it creates the views as well**
- This almost works all on its on. We just need to add a line of code to Program.cs
```
builder.Services.AddDbContext<DATABASE_MODEL_NAME>();
```
- Last thing, we want to add a link in our header. Do this through Views -> Shares -> Layout. 
	- One of the list items `<li>` has what you need to copy. Replace the controller and view with yours that you made.

Doing these should mean that the application runs. 

### Further Applications

To create something more complex, I'd recommend GPT.

```
Assist me in creating a C# Asp.Net Core Web App - MVC. 
I've added the University controller. State should not be its own controller, instead, it will replace the "Index" action and list all of the states.  want to make it to where I can click on a State name, and it takes me to a URL with it, that lists every university in that state. 
For instance, clicking on KS I get the url 
localhost:5180/Universities/States/KS
```
