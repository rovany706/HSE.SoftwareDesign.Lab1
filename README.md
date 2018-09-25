# Лабораторная работа 1 - Дерево идентификаторов
### Задание
Построить дерево, содержащее информацию об идентификаторах анализируемой компилятором программы.

**Каждая вершина дерева содержит следующую информацию об идентификаторе:**
1. Имя идентификатора.
2. Значение хеш-функции, вычисленной по имени идентификатора.
3. Способ использования идентификатора – одно из значений перечислимого типа (*CLASSES, CONSTS, VARS, METHODS*).
4. Информация о типе идентификатора – одно из значений перечислимого типа (*int_type, float_type, bool_type, char_type, string_type, class_type*).
5. Если идентификатор является константой (способ использования CONSTS), то в вершине дерева необходимо хранить значение этой константы.
6. Если идентификатор является методом (способ использования METHODS), то в вершине необходимо хранить информацию о линейном списке параметров метода: тип параметра, способ передачи параметра (по значению, по ссылке, выходной).
7. Ссылки на левое и правое поддеревья.

Вершины дерева упорядочиваются в зависимости от значения хэш-функции вычисленной от имени идентификатора.

###Пример

```
int a;
const float c = 10;
class MyClass;
string method1(int x1, ref char x2, out float x3);
```

![Дерево идентификаторов](https://raw.githubusercontent.com/rovany706/HSE.SoftwareDesign.Lab1/task/tree.png)