<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeTable.aspx.cs" Inherits="EmployeeTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.1/angular.min.js"></script>
    <script src="js/JavaScript.js"></script>
    <script src="js/angular-route.min.js"></script>
</head>
<body ng-app="myModule1">
    <form id="form1" runat="server">
    <div ng-controller="myController1">
      <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>channelid</th>                    
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="employee in channelist.channellist.channel">                   
                    <td>{{employee.name}}</td>   
                     <td>{{employee.channelid}}</td>                                     
                </tr>
            </tbody>
        </table>
        <div ng-model="error"></div>
    </div>
    </form>
</body>
</html>
