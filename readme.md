# Currency Apps
Aplikasi ini menunjukkan simulasi mobil pintar semacam mobil tesla yg menggunakan teknologi modern.
# Scope & Functionalities
- User hanya menggunakan sentuhan layar untuk menutup pintu 
- Mobil tidak akan menyala jika pintu masih terbuka
- User mendapat petunjuk jika mesin belum dapat dinyalakan

## How Does it Works?
Diawali dengan method main window pada class `MainWindow.xaml.cs` kita mendeklarasikan dengan
``` csharp
 public partial class MainWindow : Window , OnPowerChanged , OnDoorChanged , OnCarEngineStateChanged 
    {
        private Car nextCar;
        public MainWindow()
        {
            InitializeComponent();

            AccubatteryController accubatteryController = new AccubatteryController(this);
            DoorController doorController = new DoorController(this);

            nextCar = new Car(doorController, accubatteryController, this);
        }

        
    }
```
Logika Controller terdapat 2 class yaitu class `AccubatteryController.cs` dan `DoorController.cs`.kelas ini berfungsi untuk mengontrol pintu untuk membuka,menutup dan mengunci.

Logika `DoorController.cs` di awali dengan deklarasikan
``` csharp
class DoorController
    {
        private Door door;
        private OnDoorChanged callbackOnDoorChanged;

        public DoorController(OnDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }

        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "Door Closed")
;        }

        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "Door Opened");
        }
        
        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("LOCKED", "Door Locked");
        }
        
        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("UNLOCKED", "Door Unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
```
Sedangkan class `Door.cs` ini berfungsi untuk mendeklarasikan untuk class `DoorController.cs`.dengan source code seperti berikut
```csharp
private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }
        public void open()
        {
            this.closed = false;
        }
        public void activateLock()
        {
            this.locked = true;
        }
        public void unlock()
        {
            this.locked = false;
        }
        public bool isLocked()
        {
            return this.locked;
        }
        public bool isClosed()
        {
            return this.closed;
        }
    }
```