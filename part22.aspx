<%@ Page Language="C#" AutoEventWireup="true" CodeFile="part22.aspx.cs" Inherits="part22" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" ng-app="demoApp1">
<head>
    <title></title>
    <script src="Scripts/angular.js"></script>
    <script src="Scripts/Script.js"></script>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body ng-controller="countryController1">
    <span ng-repeat="country in countries">
        <button ng-click="scrollTo(country.Name)">{{country.Name}}</button>
    </span>
    <br /><br />
    <div class="containerDiv">
        <fieldset ng-repeat="country in countries" id="{{country.Name}}">
            <legend>{{country.Name}}</legend>
            <ul>
                <li ng-repeat="city in country.Cities">
                    {{city.Name}}
                </li>
            </ul>
        </fieldset>
    </div>
</body>
</html>