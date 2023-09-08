# About this project
This project collects common functionality that is used in multiple modules.

# Functions
## NotifyObject
Simple implementation of a class that notifies before and after a property has changed via the `SetPropertyValue<T>` method. 
### SetPropertyValue<T>
```cs
private bool myProperty;
public bool MyProperty {
	get => myProperty;
	set => SetPropertyValue(ref myProperty, value);
}
```
This property makes use of the SetPropertyValue<T> method.
Note, that the parameter `string? propertyName` was not used. This allows the compiler to substitute this property with the caller member name (in our case "MyProperty").

First, the old property in myProperty is compared against value. If the values are identical, the method returns false, indicating, that nothing has changed. Neither PropertyChanging nor PropertyChanged were raised in this scenario.
If the values differ, the event `OnPropertyChanging` is raised presenting the old and the new value without changing the backingfield.
After that, the backingfield gets the new value and the event `OnPropertyChanged` is raised with the old and new values.
