# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #3 выполнил:
- Максименков савелий Андреевич
- НМТ220703

Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

## Цель работы
Разработать оптимальный баланс для десяти уровней игры Dragon Picker

## Задание 1
### Предложите вариант изменения найденных переменных для 10 уровней в игре. Визуализируйте изменение уровня сложности в таблице.
- Вот список переменных для балансировки уровней:
  1. Количество энергетических щитов
  2. Скорость дракона
  3. Время между спавном яиц
  4. Минимальная дистанция до края
- [Ссылка на таблицу](https://docs.google.com/spreadsheets/d/17qr9dngG86V0iL1ArPUSqTPMR3wr8O4GUYEtpGpwCmg/edit#gid=0) с данными и их визуализацией

## Задание 2
### Создайте 10 сцен на Unity с изменяющимся уровнем сложности.
- Для изменения уровня сложности я изменял переменные, перечисленные выше.
- Для изменения переменных я создал LevelController, в котором хранится номер загруженного уровня. Это необходимо для корректного переноса данных из гугл таблицы в игру.
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelController
{
    public static readonly int LevelCount = 10;
    private static int levelNumber;

    public static int GetLevelNumber()
    {
        return levelNumber;
    }

    public static void ChangeLevelNum(int levelNum)
    {
        LevelController.levelNumber = levelNum;
    }
}
```
- Для того, чтобы юзер смог выбрать любой уровень, я создал новое меню LevelMenu (скрыто по дефолту)
![изображение](https://github.com/lexaSvarshik/lab3/assets/96281939/3b68e8be-302d-46c5-9216-d7bafb807a43)

## Задание 3
### Решение в 80+ баллов должно заполнять google-таблицу данными из Python. В Python данные также должны быть визуализированы.

- Вот код, который генерирует необходимые значения и записывает их в таблицу. Данные визуализированы с помощью pyplot.

```py
import math
import gspread
import numpy as np
from matplotlib import pyplot as plt 

gc = gspread.service_account(filename='lab3-408211-43fc1f2a669b.json')
sh = gc.open("lab3")

level_count = 10
levels = [i for i in range(1, level_count+1)]

shields_num_array = [3, 3, 3, 3, 2, 2, 2, 1, 1, 1]
shields_num_table_start_index = "A3"

drakon_speed_start = 5
drakon_speed_modifier = 3
drakon_speed_table_start_index = "K3"

drakon_time_between_egg_drop_start = 1
drakon_time_between_egg_drop_modifier = -0.075
drakon_time_between_egg_drop_table_start_index = "A17"

drakon_left_right_distance_start = 10
drakon_left_right_distance_modifier = -0.25
drakon_left_right_distance_table_start_index = "K17"

def create_array(length, startNum, modifier):
    array = []
    for i in range(length):
        array.append(round(startNum + (i * modifier), 2))
    return array

def load_data(values, start_index):
      for i in range(len(values)):
            sh.sheet1.update(chr(ord(start_index[0]) + i) + str(int(start_index[1:])), values[i])
            print(chr(ord(start_index[0]) + i) + str(int(start_index[1:])), values[i])

load_data(shields_num_array, shields_num_table_start_index)
plt.plot(levels, shields_num_array)  
plt.title("Shield Num")
plt.xticks(ticks=levels, labels=levels) 
plt.xlabel('Level')
plt.ylabel('Shields')
plt.show()     
    
drakon_speed_array = create_array(level_count, drakon_speed_start, drakon_speed_modifier)
load_data(drakon_speed_array, drakon_speed_table_start_index)
plt.plot(levels, drakon_speed_array)  
plt.title("drakon Speed")
plt.xticks(ticks=levels, labels=levels) 
plt.xlabel('Level')
plt.ylabel('Speed')
plt.show()

drakon_time_between_egg_drop_array = create_array(level_count, drakon_time_between_egg_drop_start, drakon_time_between_egg_drop_modifier)
load_data(drakon_time_between_egg_drop_array, drakon_time_between_egg_drop_table_start_index)
plt.plot(levels, drakon_time_between_egg_drop_array)  
plt.title("Time between egg drop")
plt.xticks(ticks=levels, labels=levels) 
plt.xlabel('Level')
plt.ylabel('Time')
plt.show()

drakon_left_right_distance_array = create_array(level_count, drakon_left_right_distance_start, drakon_left_right_distance_modifier)
load_data(drakon_left_right_distance_array, drakon_left_right_distance_table_start_index)
plt.plot(levels, drakon_left_right_distance_array)  
plt.title("drakon Left Right distance")
plt.xticks(ticks=levels, labels=levels) 
plt.xlabel('Level')
plt.ylabel('Distance')
plt.show()
```

## Выводы

В процессе выполнения лабораторной работы был изучен прототип игры Dragon Picker, найдены переменные, пригодные для балансировки уровня сложности, реализована систему контроля уровней, перенос данных из Python в Google Sheets, а также визуалированы данные для балансировки игры в Python при помощи pyplot.
