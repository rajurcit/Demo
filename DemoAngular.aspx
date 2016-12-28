<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoAngular.aspx.cs" Inherits="DemoAngular" %>

<!DOCTYPE html>

<html ng-app="myModule">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.1/angular.min.js"></script>
    <script src="js/JavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <label>Name:</label>
      <input type="text" ng-model="yourName" placeholder="Enter a name here">
      <hr>
      <h1>Hello {{yourName}}!</h1>
        <div>10+20={{10+20}}
        </div>
        
    </div>
       <br />
        <div ng-controller="myController">
    <div>First Name : {{ employee.firstName }}</div>
    <div>Last Name : {{ employee.lastName }}</div>
    <div>Gender : {{ employee.gender}}</div>
 

        <br />

         <table>
            <thead>
                <tr>
                    <th>Firstname</th>
                    <th>Lastname</th>
                    <th>Gender</th>
                    <th>Salary</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="employee in employees">
                    <td> {{ employee.firstName }} </td>
                    <td> {{ employee.lastName }} </td>
                    <td> {{ employee.gender }} </td>
                    <td> {{ employee.salary }} </td>
                </tr>
            </tbody>
        </table>
               <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Likes</th>
                    <th>Dislikes</th>
                    <th>Like/Dislike</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="technology in technologies">
                    <td> {{ technology.name }} </td>
                    <td style="text-align:center"> {{ technology.likes }} </td>
                    <td style="text-align:center"> {{ technology.dislikes }} </td>
                    <td>
                        <input type="button" ng-click="incrementLikes(technology)" value="Like" />
                        <input type="button" ng-click="incrementDislikes(technology)" value="Dislike" />
                    </td>
                </tr>
            </tbody>
        </table>
</div>
        <div ng-controller="mycontry">
        <ul ng-repeat="country in countries">
            <li>
                {{country.name}}
                <ul>
                    <li ng-repeat="city in country.cities">
                        {{city.name}}
                    </li>
                </ul>
            </li>
        </ul>
            <ul ng-repeat="country in countries" ng-init="parentIndex = $index">
            <li>
                {{country.name}} - Index = {{ $index }}
                <ul>
                    <li ng-repeat="city in country.cities">
                        {{city.name}} - Parent Index = {{ parentIndex }}, Index = {{ $index }}
                    </li>
                </ul>
            </li>
        </ul>
    </div>
        <div ng-controller="myController">
        Rows to display : <input type="number" step="1"
                                 ng-model="rowCount" max="5" min="0" />
        <br /><br />
        <div ng-controller="myController">
        <input type="text" placeholder="Search name" ng-model="searchText.firstName" />
        <input type="text" placeholder="Search gender" ng-model="searchText.gender" />
        <input type="checkbox" ng-model="exactMatch" /> Exact Match
             <input type="checkbox" ng-model="hideSalary" />Hide Salary
        <br /><br />
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Date of Birth</th>
                    <th>Gender</th>
                    <th>Salary</th>
                </tr>
            </thead>
            <tbody>
                <tr ng-repeat="employee in employees | filter: searchText : exactMatch">
                    <td>
                        {{ employee.firstName }}
                    </td>
                    <td>
                        {{ employee.dateOfBirth | date:"dd-MM-yyyy" }}
                    </td>
                    <td>
                        {{ employee.gender }}
                    </td>
                    <td ng-show="!hideSalary">
                        {{ employee.salary  }}
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </div>
    </form>
</body>
</html>
