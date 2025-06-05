from abc import ABC, abstractmethod

# --- Abstract Base Class ---
class Vehicle(ABC):
    def __init__(self, brand):
        self.brand = brand

    @abstractmethod
    def start_engine(self):  # Abstract method
        pass

    @abstractmethod
    def stop_engine(self):   # Abstract method
        pass

    def vehicle_info(self):  # Concrete method
        print(f"Brand: {self.brand}")

# --- Subclass that implements all abstract methods ---
class Car(Vehicle):
    def start_engine(self):
        print(f"{self.brand} car engine started.")

    def stop_engine(self):
        print(f"{self.brand} car engine stopped.")

# --- Another Subclass ---
class Bike(Vehicle):
    def start_engine(self):
        print(f"{self.brand} bike engine started.")

    def stop_engine(self):
        print(f"{self.brand} bike engine stopped.")

# --- Create objects ---
car = Car("Toyota")
bike = Bike("Yamaha")

car.vehicle_info()
car.start_engine()
car.stop_engine()

bike.vehicle_info()
bike.start_engine()
bike.stop_engine()

# --- Abstract class cannot be instantiated directly ---
# vehicle = Vehicle("Generic")  # ❌ Raises TypeError
