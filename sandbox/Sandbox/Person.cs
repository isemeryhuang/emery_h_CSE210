using System;

class Person {

    private string givenName;
    private string familyName;
    public Person(string givenName, string familyName) {
        this.givenName = givenName;
        this.familyName = familyName;

    }

    Pubilc void EasternStyleName (){
        Console.WriteLine($"{this.familyName}, {this.givenName}");
    }
    
    Public void WesternStyleName (){
        Console.WriteLine($"{this.familyName}, {this.givenName}");
    }
    
}