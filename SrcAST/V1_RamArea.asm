    SECTION BSS ;Block Started by Symbol - Data initialised to Zero
;dc.l won't work in BSS - use DS commands instead
	
screen_mem:				;Reserve screen memory 
    ds.b    32256

ScreenBase: ds.l 1		;Var for base of screen ram
		
UserRam:				;Data area for Vars (4k)
	ds 1024
	
