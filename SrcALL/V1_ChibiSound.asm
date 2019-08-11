	ifd BuildX68
		include "\SrcX68\V1_ChibiSound.asm"
	endif
	ifd BuildAST
		include "\SrcAST\V1_ChibiSound.asm"
	endif
	ifd BuildNEO
		include "\SrcNEO\V1_ChibiSound.asm"
	endif
	ifd BuildGEN
		include "\SrcGEN\V1_ChibiSound.asm"
	endif
	ifd BuildAMI
		include "\SrcAMI\V1_ChibiSound.asm"
	endif