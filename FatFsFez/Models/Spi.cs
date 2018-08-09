using GHIElectronics.TinyCLR.Devices.Spi;
using GHIElectronics.TinyCLR.Pins;
using System.Diagnostics;

namespace FatFsFez
{
    static class Spi
    {
        static SpiDevice device = null;
        const int DUMMY_CS_PIN_NUM = FEZ.GpioPin.D7;

        /* usi.S: Initialize MMC control ports */
        public static void InitSpi()
        {
            if (device == null)
            {
                var settings = new SpiConnectionSettings(DUMMY_CS_PIN_NUM)   // The slave's select pin. Not used. CS is controlled by by GPIO pin
                {
                    Mode = SpiMode.Mode0,
                    ClockFrequency = 15 * 1000 * 1000,       //15 Mhz
                    DataBitLength = 8,
                };
                device = SpiDevice.FromId(FEZ.SpiBus.Spi1, settings);
                Debug.WriteLine("Spi device successfully created");
            }

        }

        /* usi.S: Send a byte to the MMC */
        public static void XmitSpi(byte d)
        {
            byte[] writeBuf = { d };
            device.Write(writeBuf);
        }

        /* usi.S: Send a 0xFF to the MMC and get the received byte */
        public static byte RcvSpi()
        {
            byte[] writeBuf = { 0xff };
            byte[] readBuf = { 0x00 };

            device.TransferFullDuplex(writeBuf, readBuf);
            return readBuf[0];
        }

    }
}
