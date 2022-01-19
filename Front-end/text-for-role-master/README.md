You are given a list of roles as an array and a play script as a string.
Each line of the play script is given as follows: <Role: text>.
The text can contain any characters.
Create a function that will regroup the lines according to roles, number them and return the result in the form of ready-made text (see example). Each group is displayed as follows:

Role:   
i) text  
j) text2  
...
== line break ==  

i and j are the line numbers in the script. Line indexing starts with one, the groups should be displayed in accordance with the order of roles. Line breaks between groups are required, line breaks at the end of the text are not taken into account.

Sample Input: 

roles: 
[ "Городничий", "Аммос Федорович", "Артемий Филиппович", "Лука Лукич"] 

textLines:
                
    "Городничий: Я пригласил вас, господа, с тем, чтобы сообщить вам пренеприятное известие: к нам едет ревизор.
        Аммос Федорович: Как ревизор?
        Артемий Филиппович: Как ревизор?
        Городничий: Ревизор из Петербурга, инкогнито. И еще с секретным предписаньем.
        Аммос Федорович: Вот те на!
        Артемий Филиппович: Вот не было заботы, так подай!
        Лука Лукич: Господи боже! еще и с секретным предписаньем!"
                
Sample Output:
 
    Городничий: 
    1) Я пригласил вас, господа, с тем, чтобы сообщить вам пренеприятное известие: к нам едет ревизор. 
    4) Ревизор из Петербурга, инкогнито. И еще с секретным предписаньем.

    Аммос Федорович: 
    2) Как ревизор? 
    5) Вот те на! 

    Артемий Филиппович: 
    3) Как ревизор? 
    6) Вот не было заботы, так подай!
 
    Лука Лукич:
    7) Господи боже! еще и с секретным предписаньем! 

