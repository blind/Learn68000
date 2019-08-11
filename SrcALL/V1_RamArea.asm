	ifd BuildAST
		include "\SrcAST\V1_RamArea.asm"
	endif
	ifd BuildX68
		include "\SrcX68\V1_RamArea.asm"
	endif
	ifd BuildAMI
		include "\SrcAMI\V1_RamArea.asm"
	endif