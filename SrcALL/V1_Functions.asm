	ifd BuildAST
		include "\SrcAST\V1_Functions.asm"
	endif
	ifd BuildGEN
		include "\SrcGEN\V1_Functions.asm"
	endif
	ifd BuildX68
		include "\SrcX68\V1_Functions.asm"
	endif
	ifd BuildAMI
		include "\SrcAMI\V1_Functions.asm"
	endif
	ifd BuildNEO
		include "\SrcNEO\V1_Functions.asm"
	endif
	ifd BuildSQL
		include "\SrcSQL\V1_Functions.asm"
	endif