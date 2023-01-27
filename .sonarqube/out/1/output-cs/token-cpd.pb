ñ
[C:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Commands\Heroes\CreateHeroCommand.cs
	namespace 	
Core
 
. 
Commands 
. 
Heroes 
{ 
public 

class 
CreateHeroCommand "
:# $
IRequest% -
<- .
Result. 4
<4 5
HeroResponse5 A
>A B
>B C
{ 
public		 
string		 
Nome		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
}

 
} ×
jC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Commands\Heroes\Handler\CreateHeroCommandHandler.cs
	namespace		 	
Core		
 
.		 
Commands		 
.		 
Heroes		 
.		 
Handler		 &
{

 
public 

class $
CreateHeroCommandHandler )
:* +
IRequestHandler, ;
<; <
CreateHeroCommand< M
,M N
ResultO U
<U V
HeroResponseV b
>b c
>c d
{ 
private 
readonly 
IHeroRepository (
heroRepository) 7
;7 8
private 
readonly 
IUnitOfWork $

unitOfWork% /
;/ 0
private 
readonly 
IMapper  
mapper! '
;' (
public $
CreateHeroCommandHandler '
(' (
IHeroRepository( 7
heroRepository8 F
,F G
IUnitOfWorkH S

unitOfWorkT ^
,^ _
IMapper` g
mapperh n
)n o
{ 	
this 
. 
heroRepository 
=  !
heroRepository" 0
;0 1
this 
. 

unitOfWork 
= 

unitOfWork (
;( )
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
<  !
HeroResponse! -
>- .
>. /
Handle0 6
(6 7
CreateHeroCommand7 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 	
var 
result 
= 
new 
Result #
<# $
HeroResponse$ 0
>0 1
(1 2
)2 3
;3 4
var 
hero 
= 
mapper 
. 
Map !
<! "
Hero" &
>& '
(' (
request( /
)/ 0
;0 1
try 
{ 

unitOfWork   
.   
OpenTransaction   *
(  * +
)  + ,
;  , -
await"" 
heroRepository"" $
.""$ %
AddAsync""% -
(""- .
hero"". 2
)""2 3
;""3 4
await$$ 

unitOfWork$$  
.$$  !"
CommitTransactionAsync$$! 7
($$7 8
)$$8 9
;$$9 :
}%% 
catch&& 
(&& 
	Exception&& 
ex&& 
)&&  
{'' 

unitOfWork(( 
.(( 
RollbackTransaction(( .
(((. /
)((/ 0
;((0 1
})) 
result++ 
.++ 
Value++ 
=++ 
mapper++ !
.++! "
Map++" %
<++% &
HeroResponse++& 2
>++2 3
(++3 4
hero++4 8
)++8 9
;++9 :
return-- 
result-- 
;-- 
}.. 	
}// 
}00 þ
NC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Entities\Heroes\Hero.cs
	namespace 	
Core
 
. 
Entities 
. 
Heroes 
{ 
public 

class 
Hero 
: 

BaseEntity "
{ 
public 
string 
? 
Nome 
{ 
get !
;! "
set# &
;& '
}( )
} 
}		 Ø
PC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Interfaces\IUnitOfWork.cs
	namespace 	
Core
 
. 

Interfaces 
{ 
public 

	interface 
IUnitOfWork  
:! "
IDisposable# .
{ 
void #
CreateExecutionStrategy $
($ %
)% &
;& '!
IDbContextTransaction		 
OpenTransaction		 -
(		- .
)		. /
;		/ 0
void 
RollbackTransaction  
(  !
)! "
;" #
Task "
CommitTransactionAsync #
(# $
)$ %
;% &
} 
} ˜
hC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Interfaces\Repositories\Heroes\IHeroRepository.cs
	namespace 	
Core
 
. 

Interfaces 
. 
Repositories &
.& '
Heroes' -
{ 
public 

	interface 
IHeroRepository $
:% &
IBaseRepository' 6
<6 7
Hero7 ;
>; <
{ 
Task 
< 
AsyncOutResult 
< 
IEnumerable '
<' (
Hero( ,
>, -
,- .
int/ 2
>2 3
>3 4
Get5 8
(8 9
string9 ?
nome@ D
,D E
intF I
?I J
takeK O
,O P
intQ T
?T U
offSetV \
,\ ]
string^ d
sortingPrope p
,p q
boolr v
?v w
ascx {
){ |
;| }
}		 
}

 Î
aC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Interfaces\Repositories\IBaseRepository.cs
	namespace 	
Core
 
. 

Interfaces 
. 
Repositories &
{ 
public 

	interface 
IBaseRepository $
<$ %
TEntity% ,
>, -
where. 3
TEntity4 ;
:< =
class> C
{ 
Task 
< 
TEntity 
> 
GetById 
( 
Guid "
id# %
)% &
;& '
Task		 
<		 
AsyncOutResult		 
<		 
IEnumerable		 '
<		' (
TEntity		( /
>		/ 0
,		0 1
int		2 5
>		5 6
>		6 7
GetAll		8 >
(		> ?
int		? B
?		B C
take		D H
,		H I
int		J M
?		M N
offSet		O U
,		U V
string		W ]
sortingProp		^ i
,		i j
bool		k o
?		o p
asc		q t
)		t u
;		u v
Task 
< 
IEnumerable 
< 
TEntity  
>  !
>! "
Get# &
(& '
int' *
?* +
take, 0
,0 1
int2 5
?5 6
offSet7 =
,= >
string? E
sortingPropF Q
,Q R
boolS W
?W X
ascY \
)\ ]
;] ^
Task 
< 
TEntity 
> 
AddAsync 
( 
TEntity &
entity' -
)- .
;. /
Task 
< 
IEnumerable 
< 
TEntity  
>  !
>! "
AddRangeAsync# 0
(0 1
IEnumerable1 <
<< =
TEntity= D
>D E
entityF L
)L M
;M N
Task 
< 
bool 
> 
UpdateAsync 
( 
TEntity &
entity' -
)- .
;. /
Task 
< 
bool 
> 
UpdateRangeAsync #
(# $
IEnumerable$ /
</ 0
TEntity0 7
>7 8

listEntity9 C
)C D
;D E
Task 
< 
bool 
> 
DeleteAsync 
( 
TEntity &
entity' -
)- .
;. /
Task 
< 
bool 
> 
DeleteRangeAsync #
(# $
IEnumerable$ /
</ 0
TEntity0 7
>7 8

listEntity9 C
)C D
;D E
} 
} •

`C:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Interfaces\Security\IAuthenticatedUser.cs
	namespace 	
Core
 
. 

Interfaces 
. 
Security "
{ 
public 

	interface 
IAuthenticatedUser '
{ 
string 
Email 
( 
) 
; 
string		 
Name		 
(		 
)		 
;		 
string 
RemoteIp 
( 
) 
; 
Guid 
	GuidLogin 
( 
) 
; 
IEnumerable 
< 
Claim 
> 
GetClaimsIdentity ,
(, -
)- .
;. /
string 
GetPermissionClaims "
(" #
)# $
;$ %
string 
GetGroupsClaims 
( 
)  
;  !
string 
GetTokenTypeClaims !
(! "
)" #
;# $
string 
GetUserAgent 
( 
) 
; 
string 
GetToken 
( 
) 
; 
} 
} Ì
PC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Mapping\RequestProfile.cs
	namespace 	
Core
 
. 
Mapping 
{ 
public 

class 
ResquestProfile  
:! "
Profile# *
{ 
public		 
ResquestProfile		 
(		 
)		  
{

 	
	CreateMap 
< 
CreateHeroCommand '
,' (
Hero) -
>- .
(. /
)/ 0
;0 1
} 	
} 
} È
QC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Mapping\ResponseProfile.cs
	namespace 	
Core
 
. 
Mapping 
{ 
public 

class 
ResponseProfile  
:! "
Profile# *
{ 
public		 
ResponseProfile		 
(		 
)		  
{

 	
	CreateMap 
< 
Hero 
, 
HeroResponse (
>( )
() *
)* +
;+ ,
} 	
} 
} ¨
PC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Mapping\ServiceProfile.cs
	namespace 	
Core
 
. 
Mapping 
{ 
public 

class 
ServiceProfile 
:  !
Profile" )
{ 
public 
ServiceProfile 
( 
) 
{ 	
}		 	
}

 
} ƒ
WC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Models\Responses\HeroResponse.cs
	namespace 	
Core
 
. 
Models 
. 
	Responses 
{ 
public 

class 
HeroResponse 
: 
BaseResponse  ,
{ 
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
} 
}		 Ù
UC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Queries\Heroes\GetHeroQuery.cs
	namespace 	
Core
 
. 
Queries 
. 
Heroes 
{ 
public 

class 
GetHeroQuery 
: 
BaseRequestFilter  1
,1 2
IRequest3 ;
<; <
Result< B
<B C
IEnumerableC N
<N O
HeroResponseO [
>[ \
>\ ]
>] ^
{		 
public

 
string

 
?

 
Nome

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
} 
} Â
dC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Queries\Heroes\Handler\GetHeroQueryHandler.cs
	namespace 	
Core
 
. 
Queries 
. 
Heroes 
. 
Handler %
{ 
public		 

class		 
GetHeroQueryHandler		 $
:		% &
IRequestHandler		' 6
<		6 7
GetHeroQuery		7 C
,		C D
Result		E K
<		K L
IEnumerable		L W
<		W X
HeroResponse		X d
>		d e
>		e f
>		f g
{

 
private 
readonly 
IHeroRepository (
heroRepository) 7
;7 8
private 
readonly 
IMapper  
mapper! '
;' (
public 
GetHeroQueryHandler "
(" #
IHeroRepository# 2
heroRepository3 A
,A B
IMapperC J
mapperK Q
)Q R
{ 	
this 
. 
heroRepository 
=  !
heroRepository" 0
;0 1
this 
. 
mapper 
= 
mapper  
;  !
} 	
public 
async 
Task 
< 
Result  
<  !
IEnumerable! ,
<, -
HeroResponse- 9
>9 :
>: ;
>; <
Handle= C
(C D
GetHeroQueryD P
queryQ V
,V W
CancellationTokenX i
cancellationTokenj {
){ |
{ 	
var 
result 
= 
new 
Result #
<# $
IEnumerable$ /
</ 0
HeroResponse0 <
>< =
>= >
(> ?
)? @
;@ A
var 
heroes 
= 
await 
heroRepository -
.- .
Get. 1
(1 2
query2 7
.7 8
Nome8 <
,< =
null> B
,B C
nullD H
,H I
$strJ P
,P Q
nullR V
)V W
;W X
result 
. 
Value 
= 
mapper !
.! "
Map" %
<% &
IEnumerable& 1
<1 2
HeroResponse2 >
>> ?
>? @
(@ A
heroesA G
.G H
ResultH N
(N O
outO R
varS V
countW \
)\ ]
)] ^
;^ _
result 
. 
Count 
= 
count  
;  !
return 
result 
; 
} 	
} 
}   »-
UC:\Users\patrick.braga\source\repos\Hero\src\Hero.Core\Sercurity\AuthenticatedUser.cs
	namespace 	
Core
 
. 
	Sercurity 
{ 
public 

class 
AuthenticatedUser "
:# $
IAuthenticatedUser% 7
{ 
private		 
readonly		  
IHttpContextAccessor		 -
	_accessor		. 7
;		7 8
public 
AuthenticatedUser  
(  ! 
IHttpContextAccessor! 5
accessor6 >
)> ?
{ 	
	_accessor 
= 
accessor  
;  !
} 	
public 
string 
Email 
( 
) 
{ 	
return 
	_accessor 
. 
HttpContext (
.( )
User) -
.- .
Identity. 6
.6 7
Name7 ;
;; <
} 	
public 
string 
Name 
( 
) 
{ 	
return 
GetClaimsIdentity $
($ %
)% &
.& '
FirstOrDefault' 5
(5 6
a6 7
=>8 :
a; <
.< =
Type= A
==B D

ClaimTypesE O
.O P
NameP T
)T U
?U V
.V W
ValueW \
;\ ]
} 	
public 
string 
RemoteIp 
( 
)  
{ 	
return 
	_accessor 
. 
HttpContext (
.( )

Connection) 3
.3 4
RemoteIpAddress4 C
.C D
	MapToIPv4D M
(M N
)N O
.O P
ToStringP X
(X Y
)Y Z
;Z [
} 	
public 
Guid 
	GuidLogin 
( 
) 
{   	
try!! 
{"" 
var## 
	guidLogin## 
=## 
GetClaimsIdentity##  1
(##1 2
)##2 3
.##3 4
FirstOrDefault##4 B
(##B C
a##C D
=>##E G
a##H I
.##I J
Type##J N
==##O Q
$str##R V
)##V W
?##W X
.##X Y
Value##Y ^
;##^ _
return%% 
string%% 
.%% 
IsNullOrEmpty%% +
(%%+ ,
	guidLogin%%, 5
)%%5 6
?%%7 8
Guid%%9 =
.%%= >
Empty%%> C
:%%D E
Guid%%F J
.%%J K
Parse%%K P
(%%P Q
	guidLogin%%Q Z
)%%Z [
;%%[ \
}&& 
catch'' 
('' 
	Exception'' 
)'' 
{(( 
return)) 
Guid)) 
.)) 
Empty)) !
;))! "
}** 
}++ 	
public-- 
string-- 
GetToken-- 
(-- 
)--  
{.. 	
	_accessor// 
.// 
HttpContext// !
.//! "
Request//" )
.//) *
Headers//* 1
.//1 2
TryGetValue//2 =
(//= >
$str//> M
,//M N
out//O R
var//S V
token//W \
)//\ ]
;//] ^
return11 
token11 
;11 
}22 	
public44 
IEnumerable44 
<44 
Claim44  
>44  !
GetClaimsIdentity44" 3
(443 4
)444 5
{55 	
return66 
	_accessor66 
?66 
.66 
HttpContext66 )
?66) *
.66* +
User66+ /
?66/ 0
.660 1
Claims661 7
;667 8
}77 	
public99 
string99 
GetPermissionClaims99 )
(99) *
)99* +
{:: 	
return;; 
	_accessor;; 
.;; 
HttpContext;; (
.;;( )
User;;) -
.;;- .
Claims;;. 4
.;;4 5
FirstOrDefault;;5 C
(;;C D
f;;D E
=>;;F H
f;;I J
.;;J K
Type;;K O
==;;P R
$str;;S _
);;_ `
?;;` a
.;;a b
Value;;b g
;;;g h
}<< 	
public>> 
string>> 
GetGroupsClaims>> %
(>>% &
)>>& '
{?? 	
return@@ 
	_accessor@@ 
.@@ 
HttpContext@@ (
.@@( )
User@@) -
.@@- .
Claims@@. 4
.@@4 5
FirstOrDefault@@5 C
(@@C D
f@@D E
=>@@F H
f@@I J
.@@J K
Type@@K O
==@@P R
$str@@S [
)@@[ \
?@@\ ]
.@@] ^
Value@@^ c
;@@c d
}AA 	
publicCC 
stringCC 
GetTokenTypeClaimsCC (
(CC( )
)CC) *
{DD 	
returnEE 
	_accessorEE 
.EE 
HttpContextEE (
.EE( )
UserEE) -
.EE- .
ClaimsEE. 4
.EE4 5
FirstOrDefaultEE5 C
(EEC D
fEED E
=>EEF H
fEEI J
.EEJ K
TypeEEK O
==EEP R
$strEES Y
)EEY Z
?EEZ [
.EE[ \
ValueEE\ a
;EEa b
}FF 	
publicHH 
stringHH 
GetUserAgentHH "
(HH" #
)HH# $
{II 	
returnJJ 
	_accessorJJ 
.JJ 
HttpContextJJ (
.JJ( )
RequestJJ) 0
.JJ0 1
HeadersJJ1 8
[JJ8 9
$strJJ9 E
]JJE F
;JJF G
}KK 	
}LL 
}MM 