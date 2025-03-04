How to download and access project:
1. Open terminal at desired folder. Run "git clone https://github.com/Arcweaver/COMP3329-game-project"
2. Open unity. Detect the project folder.
3. You should see an empty scene and an empty hierarchy. Go to scenes folder and open a scene (default should be the GameMenu.unity). This should populate both windows.

Update local project:
1. git pull

Commit changes:
1. git add .
2. (optional) git status
3. git push -u origin main   (or other branches)


-------------------------------------------------------------------------------------------------------------------------------------
Notes on implementation:
-------------------------------------------------------------------------------------------------------------------------------------

Player/Enemy/Boss units:
All units in the game are extended from the UnitTemplate class. The UnitTemplate class handles basic stat data of the units, as well as some important updates. 
If you want to extend a class from UnitTemplate (and related templates, eg EnemyTemplate/BossTemplate), you should call the CallOnUpdate() method at the beginning of the Update() method.

CallOnUpdate() performs the following:
modifiedStat's core stats converted to default values => iterate through a list of StatModifier to modify the stats & update StatModifier's timers/existance

All units have their stats moditored using a UnitStat class. This class serves as both a core stat container, as well as a carrier for some other values you may want to track. If you want to read stat values from the units for post-processing, please obtain them via GetModifiedStats(), as it will also handle additional stat changes due to some modifiers.
On a side note, if you want to track some custom values, feel free to declare them in the UnitStat class. However, note that these additional stats will need to be tracked/modified through other means (eg in StatModifier's methods), and the UnitTemplate class will only handle the default core stats.

------------------------------------------------------------------------------------------------------------------------------------

Skills:
The usage of skills is implemented using the Skill class, which in turn may create 2 objects: a skillshot and a statmodifier. Default behaviour is that a skill will create at most 1 of each object. If you want to create more, feel free to override/declare some variables and methods.

The Skill class should only handle the creation of the generated objects, as well as handle skill name and descriptions.

The SkillShot class will generate "bullets" that hits enemies/players. On hit detection, if there is a damage/heal event, please handle them using CombatParser.CombatParsing().

The StatModifier class will handle stat modifications. All stat modifications should be done on the UnitStat class passed into it, not the UnitStat in the UnitTemplate passed into it.
Note that care should be taken to handle which changes should only be called on update, and which can be called regardless of update.
The StatModifier itself should have handled its timer and removal logics. You should only handle the initialization of the timer, or special timer expirations.

You may refer to the implementation of the skills Frostfire Lance and Quicksilver for details
