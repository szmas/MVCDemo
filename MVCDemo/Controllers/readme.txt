/


==========================controller 往 view 传递数据==========================



/



==========viewData=============

key/value字典集合


viewData 比viewBag 快


==============viewBag===============

dynamic类型


viewBag内部调用了viewData




可以传递ViewData，接收时获取ViewBag

viewBag是viewData的一个语法糖



===========理解强类型View========
action

User user=new User()
return view(user);

view

@model Model.User;


@Model.name;
@Model.age


设置强类型视图是最佳解决方案。



===================ViewModel 解决方案===================

ViewModel是隐式声明的层， 用于维护Model与view之间的数据传递

Model是业务和数据结构创建，ViewModel是视图相关的数据，根据View创建

Model和ViewModel是相互独立的，Controller根据Model对象创建ViewModel

每个View有其对应的ViewModel。

viewModel其实就是view需要的数据，过滤的原始的Model。是view不包含业务逻辑处理，
因为Controller在创建viewModel时，已经把业务逻辑处理了一遍，生成view想要的数据viewModel,View只需要负责显示





/*


==========================view 往 controller 传递数据==========================


*/


Model Binder

无论请求是否由带参的action方法生成，Model Binder都会自动执行。
Model Binder会通过方法的元参数迭代，然后会和接收到参数名称做对比。如果匹配，则响应接收的数据，并分配给参数。
在Model Binder迭代完成之后，将类参数的每个属性名称与接收的数据做对比，如果匹配，则响应接收的数据，并分配给参数。


内部action 方法，获取请求中的post数据。Form 语法和手动构建Model对象：


使用参数名称和手动创建Model对象：


自定义Model Binder





Model Binder需要更新Model State。Model State封装了 Model状态。

ModelState包含属性IsValid ，该属性表示 Model 是否成功更新。如果任何服务器端验证失败，Model将不更新。

ModelState保存验证错误的详情。

如：ModelState[“FirstName”],表示将包含所有与First Name相关的错误。


当参数为类，Model Binder将通过检索类所有的属性，将接收的数据与类属性名称比较。


ValidationMessage 是运行时执行的函数。如之前讨论的，ModelBinder更新ModelState。ValidationMessage根据关键字显示ModelState表示的错误信息。




自定义服务器端验证

FirstNameValidation:ValidationAttribute



添加客户端验证


Validations.js


ModelState.AddModelError("CredentialError", "Invalid Username or Password");



登录页面实现客户端验证


jQuery unobtrusive Validation.js


@Html.TextBoxFor(x=>x.UserName)
@Html.ValidationMessageFor(x=>x.UserName)