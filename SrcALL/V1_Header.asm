	ifd BuildAST
		include "\SrcAST\V1_Header.asm"
	endif
	ifd BuildGEN
		include "\SrcGEN\V1_Header.asm"
	endif
	ifd BuildX68
		include "\SrcX68\V1_Header.asm"
	endif
	ifd BuildAMI
		include "\SrcAMI\V1_Header.asm"
	endif
	ifd BuildNEO
		include "\SrcNEO\V1_Header.asm"
	endif
	ifd BuildSQL
		include "\SrcSQL\V1_Header.asm"
	endif