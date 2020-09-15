| SpacePort     |                    |
| ------------- |:------------------:|
| SpacePortID   | int                |
| ParkingLot    | int                |
| ParkingStatus | ENUM (Open, Closed)|


| ParkingLot         |                    |
| ------------------ |:------------------:|
| ParkingLotID       | int                |
| SpacePortID        | int                |
| ParkingLotOccupied | bool               |


| Visitor   |                        |
| --------- |:----------------------:|
| HasPayed  | ENUM (HasPaid, NotPaid)|
| Name      | string                 |
| VisitorID | int                    |


| SpaceShip     |               |
| ------------- |:-------------:|
| TravelerID    | int           |
| SpaceShipID   | int           |


| Receipt       |               |
| ------------- |:-------------:|
| SpaceCredit   | int           |
| VisitorID     | int           |
| Date          | DateTime      |
| ReceiptID     | int           |
