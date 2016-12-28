<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="EmployeeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.1/angular.min.js"></script>
    <script src="js/JavaScript.js"></script>
</head>
<body ng-app="myModule">
    <form id="form1" runat="server">
     <div ng-controller="myController">
        Select View :
        <select ng-model="employeeView">
            <option value="EmployeeTable.aspx">Table</option>
            <option value="EmployeeList.aspx">List</option>
        </select>
        <br /><br />
        <div ng-include="employeeView">
             <div ng-include="employeeList"></div>
        </div>
         <ul ng-repeat="employee in employees">
    <li>
        {{employee.name}}
        <ul>
            <li>{{employee.gender}}</li>
            <li>{{employee.salary}}</li>
        </ul>
    </li>
</ul>
    </div>
        
    </form>
</body>
</html>
