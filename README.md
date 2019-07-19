# TestTask
MyFirstWebApplication<br>
Всё работает, кроме:<br>
	-не принимает данные в формате json, только через параметры и context.Request.Query. Отдаёт, как положено.<br>
	-без Autofac.<br>
values.json выглядит так:<br>
	{ "Value":[value1, value2, ... ], "Time":[time1, time2, ...] },<br>
	то есть каждый пост запрос добавляет новую запись в списки.<br>
