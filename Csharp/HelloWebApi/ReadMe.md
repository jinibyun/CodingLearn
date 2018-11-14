# Steps To Approach

### Web Api Restful Service Concept
	
### xxx

### xxx


### Parameter Binding 
Action methods in Web API controller can have one or more parameters of different types.It can be either primitive type or complex type
By default, if parameter type is of .NET primitive type such as int, bool, double, string, GUID, DateTime, decimal or any other type that can be converted from string type then it sets the value of a parameter from the query string. And if the parameter type is complex type then Web API tries to get the value from request body by default.


| HTTP Method | Query String |Request Body |
| ------      | ----------- |-------------------|
| GET         |  Primitive Type, Complex Type| N/A |
| POST      |  Primitive Type| Comples Type|
| PUT         |  Primitive Type| Complex Type|
| DELETE         |  Primitive Type, Complex Type| N/A |


**Example**



