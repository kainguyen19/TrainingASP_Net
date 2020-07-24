# URL of ASP.Net MVC

## 0. Introduce URL in ASP.Net MVC
* https://domain/ 			=> controller: home; action:index
* https://domain/controller		=> controller: controller; action: index

## 1. Send parameter (id) to Server
* https://domain/controller/action/2	
    * controller: controller; 
    * action: action; 
    * id=2
	
=> DetailProduct => idProduct

## 2. Send multiple parameter to Server
* GET method:
    * https://domain/controller/action?para_1=value_1&para_2=value_2
* POST method:
    * https://domain/controller/action
        * Parameter is hidden