# TestTask
MyFirstWebApplication<br>
Коммит 1:<br>
Всё работает, кроме:<br>
	-не принимает данные в формате json, только через параметры и context.Request.Query. Отдаёт, как положено.<br>
	-без Autofac.<br>
values.json выглядит так:<br>
	{ "Value":[value1, value2, ... ], "Time":[time1, time2, ...] },<br>
	то есть каждый пост запрос добавляет новую запись в списки.<br><br>
Коммит 2:<br>
То же самое, только json теперь выглядит, как:<br>
{ "Value": value1, "Time":time1},<br>
{ "Value": value2, "Time":time2},<br>
...............................<br>
{ "Value": valueN, "Time":timeN},<br>
то есть каждый пост запрос добавляет новый объект в конец файла
