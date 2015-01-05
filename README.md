### Application Icon Badge Plugin for Xamarin and Windows

### Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugin.Badge/
* Install into your PCL project and Client projects.

**Supports**
* Xamarin.iOS
* Xamarin.iOS (x64 Unified)
* Xamarin.Android
* Windows Phone 8.0
* Windows Phone 8.1 RT
* Windows Store 8.0+

Android doesn't supports app icon badge by default but third party manufacturers launchers do.

**Android OS**
* Samsung
* HTC
* LG
* Sony
* Xiaomi
* Adw
* Apex
* Asus
* Nova
* Solid
* Default (because some launchers use android.intent.action.BADGE_COUNT_UPDATE to update count)

Thanks to:

https://github.com/arturogutierrez/Badges

and

https://github.com/leolin310148/ShortcutBadger

### API Usage
```
CrossBadge.Current.SetBadge(10);
```

#### Contributors
* [sbondini](https://github.com/sbondini)
