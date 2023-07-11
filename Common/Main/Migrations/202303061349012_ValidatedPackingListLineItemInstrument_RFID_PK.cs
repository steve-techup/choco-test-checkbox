namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidatedPackingListLineItemInstrument_RFID_PK : DbMigration
    {
        public override void Up()
        {

            Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                    WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = 'ValidatedPackingListLineItemInstrument_RFID' 
                    AND TABLE_SCHEMA ='dbo')
                    BEGIN

	                    ALTER TABLE ValidatedPackingListLineItemInstrument_RFID DROP CONSTRAINT [PK_dbo.ValidatedPackingListLineItemInstrument_RFID]

                    END;
                    GO");

            Sql(@"IF EXISTS((SELECT 1 FROM sys.indexes  WHERE name = 'IX_Instrument_RFID_Instrument_ID_Instrument_RFID_EPC_Nr' AND object_id = OBJECT_ID('ValidatedPackingListLineItemInstrument_RFID')))
                    DROP INDEX IX_Instrument_RFID_Instrument_ID_Instrument_RFID_EPC_Nr ON ValidatedPackingListLineItemInstrument_RFID;
                    GO");

            Sql(@"IF EXISTS (SELECT 1 FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'ValidatedPackingListLineItemInstrument_RFID'
                      AND COLUMN_NAME = 'Instrument_RFID_EPC_Nr'
                      AND TABLE_SCHEMA='dbo')
                    BEGIN
                        ALTER TABLE ValidatedPackingListLineItemInstrument_RFID DROP COLUMN Instrument_RFID_EPC_Nr
                    END;
                    GO");




            Sql(@"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                    WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = 'ValidatedPackingListLineItemInstrument_RFID' 
                    AND TABLE_SCHEMA ='dbo')
                    BEGIN

	                    ALTER TABLE ValidatedPackingListLineItemInstrument_RFID ADD CONSTRAINT [PK_dbo.ValidatedPackingListLineItemInstrument_RFID] PRIMARY KEY (ValidatedPackingListLineItem_Id, Instrument_RFID_Instrument_ID)

                    END");
        }
        
        public override void Down()
        {
            Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 
                    WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME = 'ValidatedPackingListLineItemInstrument_RFID' 
                    AND TABLE_SCHEMA ='dbo')
                    BEGIN

	                    ALTER TABLE ValidatedPackingListLineItemInstrument_RFID DROP CONSTRAINT [PK_dbo.ValidatedPackingListLineItemInstrument_RFID]

                    END;
                    GO");

            Sql(@"IF NOT EXISTS (
                          SELECT * 
                          FROM   sys.columns 
                          WHERE  object_id = OBJECT_ID(N'[dbo].[ValidatedPackingListLineItemInstrument_RFID]') 
                                 AND name = 'Instrument_RFID_EPC_Nr'
                        )
                        BEGIN
	                        ALTER TABLE ValidatedPackingListLineItemInstrument_RFID ADD Instrument_RFID_EPC_Nr NVARCHAR(50) NOT NULL;
                        END;
                    GO");


            Sql(@"IF NOT EXISTS((SELECT 1 FROM sys.indexes  WHERE name = '[IX_Instrument_RFID_Instrument_ID_Instrument_RFID_EPC_Nr]' AND object_id = OBJECT_ID('[ValidatedPackingListLineItemInstrument_RFID]')))
                        BEGIN
	
                        CREATE NONCLUSTERED INDEX [IX_Instrument_RFID_Instrument_ID_Instrument_RFID_EPC_Nr] ON [dbo].[ValidatedPackingListLineItemInstrument_RFID]
                        (
	                        [Instrument_RFID_Instrument_ID] ASC,
	                        [Instrument_RFID_EPC_Nr] ASC
                        );

                        END;
                    GO");


        }
    }
}
