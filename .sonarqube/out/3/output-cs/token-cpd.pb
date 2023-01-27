î&
OC:\Users\patrick.braga\source\repos\Hero\src\Hero.IoC\DependencyRegistration.cs
	namespace 	
IoC
 
{ 
public 

static 
class "
DependencyRegistration .
{ 
public 
static 
void 
Register #
(# $
Assembly$ ,
assembly- 5
,5 6
IConfiguration7 E
configurationF S
,S T
IHostBuilderU a
hostb f
,f g
IServiceCollectionh z
services	{ ƒ
)
ƒ „
{ 	
var 
defaultConnection !
=" #
Environment$ /
./ 0"
GetEnvironmentVariable0 F
(F G
$strG Z
)Z [
;[ \
if 
( 
string 
. 
IsNullOrEmpty $
($ %
defaultConnection% 6
)6 7
)7 8
defaultConnection !
=" #
configuration$ 1
.1 2
GetConnectionString2 E
(E F
$strF Y
)Y Z
;Z [
Log 
. 
Logger 
= 
new 
LoggerConfiguration 0
(0 1
)1 2
. 
WriteTo 
. 
Elasticsearch &
(& '
new' *$
ElasticsearchSinkOptions+ C
(C D
newD G
UriH K
(K L
configurationL Y
[Y Z
$strZ t
]t u
)u v
)v w
{  
AutoRegisterTemplate (
=) *
true+ /
,/ 0
IndexFormat 
=  !
configuration" /
[/ 0
$str0 R
]R S
} 
) 
.   
ReadFrom   
.   
Configuration   '
(  ' (
configuration  ( 5
)  5 6
.!! 
CreateLogger!! 
(!! 
)!! 
;!!  
host## 
.## 

UseSerilog## 
(## 
)## 
;## 
services%% 
.%% 

AddMediatR%% 
(%%  
assembly%%  (
)%%( )
;%%) *
services&& 
.&& 

AddMapping&& 
(&&  
)&&  !
;&&! "
services(( 
.(( "
AddEntityConfiguration(( +
(((+ ,
defaultConnection((, =
)((= >
;((> ?,
 BuildDependencyInjectionProvider** ,
(**, -
assembly**- 5
,**5 6
host**7 ;
)**; <
;**< =
}++ 	
private-- 
static-- 
void-- ,
 BuildDependencyInjectionProvider-- <
(--< =
Assembly--= E
assembly--F N
,--N O
IHostBuilder--P \
host--] a
)--a b
{.. 	
var// 
coreAssembly// 
=// 
Assembly// '
.//' (
GetAssembly//( 3
(//3 4
typeof//4 :
(//: ;
AuthenticatedUser//; L
)//L M
)//M N
;//N O
var00 
infraAssembly00 
=00 
Assembly00  (
.00( )
GetAssembly00) 4
(004 5
typeof005 ;
(00; <
AppDbContext00< H
)00H I
)00I J
;00J K
host22 
.22 %
UseServiceProviderFactory22 *
(22* +
new22+ .)
AutofacServiceProviderFactory22/ L
(22L M
)22M N
)22N O
;22O P
host33 
.33 
ConfigureContainer33 #
<33# $
ContainerBuilder33$ 4
>334 5
(335 6
(336 7
_337 8
,338 9
builder33: A
)33A B
=>33C E
{44 
if55 
(55 
assembly55 
.55 
GetName55 $
(55$ %
)55% &
.55& '
Name55' +
==55, .
$str55/ 5
)555 6
{66 
builder77 
.77 
RegisterModule77 *
(77* +
new77+ .&
QuartzAutofacFactoryModule77/ I
(77I J
)77J K
)77K L
;77L M
builder88 
.88 
RegisterModule88 *
(88* +
new88+ .#
QuartzAutofacJobsModule88/ F
(88F G
assembly88G O
)88O P
)88P Q
;88Q R
}99 
builder;; 
.;; !
RegisterAssemblyTypes;; -
(;;- .
assembly;;. 6
,;;6 7
coreAssembly;;8 D
,;;D E
infraAssembly;;F S
);;S T
.;;T U#
AsImplementedInterfaces;;U l
(;;l m
);;m n
;;;n o
}<< 
)<< 
;<< 
}== 	
}>> 
}?? †
`C:\Users\patrick.braga\source\repos\Hero\src\Hero.IoC\Extensions\EntityConfigurationExtension.cs
	namespace 	
IoC
 
. 

Extensions 
{ 
public		 

static		 
class		 (
EntityConfigurationExtension		 4
{

 
public 
static 
IServiceCollection ("
AddEntityConfiguration) ?
(? @
this@ D
IServiceCollectionE W
servicesX `
,` a
stringb h
defaultConnectioni z
)z {
{ 	
services 
. $
AddEntityFrameworkNpgsql -
(- .
). /
./ 0
AddDbContext0 <
<< =
AppDbContext= I
>I J
(J K
optionsK R
=>S U
options 
. 
	UseNpgsql 
( 
defaultConnection 0
,0 1
options2 9
=>: <
options 
.  "
MigrationsHistoryTable  6
(6 7
$str7 N
,N O
$strP X
)X Y
)Y Z
. 
ReplaceService #
<# $ 
ISqlGenerationHelper$ 8
,8 9)
CustomNameSqlGenerationHelper: W
>W X
(X Y
)Y Z
) 
; 
return 
services 
; 
} 	
public 
class )
CustomNameSqlGenerationHelper 2
:3 4)
RelationalSqlGenerationHelper5 R
{ 	
public )
CustomNameSqlGenerationHelper 0
(0 15
)RelationalSqlGenerationHelperDependencies1 Z
dependencies[ g
)g h
: 
base 
( 
dependencies #
)# $
{% &
}' (
private 
static 
string !
	Customize" +
(+ ,
string, 2
input3 8
)8 9
=>: <
input= B
.B C
ToLowerC J
(J K
)K L
;L M
public 
override 
string "
DelimitIdentifier# 4
(4 5
string5 ;

identifier< F
)F G
=>H J
baseK O
.O P
DelimitIdentifierP a
(a b
	Customizeb k
(k l

identifierl v
)v w
)w x
;x y
public 
override 
void  
DelimitIdentifier! 2
(2 3
StringBuilder3 @
builderA H
,H I
stringJ P

identifierQ [
)[ \
=>] _
base` d
.d e
DelimitIdentifiere v
(v w
builderw ~
,~ 
	Customize
€ ‰
(
‰ Š

identifier
Š ”
)
” •
)
• –
;
– —
} 	
}   
}!! Ý
TC:\Users\patrick.braga\source\repos\Hero\src\Hero.IoC\Extensions\MappingExtension.cs
	namespace 	
IoC
 
. 

Extensions 
{ 
public 

static 
class 
MappingExtension (
{ 
public		 
static		 
IServiceCollection		 (

AddMapping		) 3
(		3 4
this		4 8
IServiceCollection		9 K
services		L T
)		T U
{

 	
var 
mappingConfig 
= 
new  #
MapperConfiguration$ 7
(7 8
mc8 :
=>; =
{ 
mc 
. 

AddProfile 
( 
new !
ResquestProfile" 1
(1 2
)2 3
)3 4
;4 5
mc 
. 

AddProfile 
( 
new !
ResponseProfile" 1
(1 2
)2 3
)3 4
;4 5
mc 
. 

AddProfile 
( 
new !
ServiceProfile" 0
(0 1
)1 2
)2 3
;3 4
} 
) 
; 
var 
mapper 
= 
mappingConfig &
.& '
CreateMapper' 3
(3 4
)4 5
;5 6
services 
. 
AddSingleton !
(! "
mapper" (
)( )
;) *
return 
services 
; 
} 	
} 
} 