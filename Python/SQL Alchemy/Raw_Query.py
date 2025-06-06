from sqlalchemy import create_engine, Column, Integer, String, text
from sqlalchemy.orm import declarative_base, sessionmaker

# Setup
engine = create_engine("mysql+pymysql://Admin:Miracle1234@localhost:3306/test_db_1", echo=True)
Base = declarative_base()
Session = sessionmaker(bind=engine)
session = Session()

# Define a simple table
class User(Base):
    __tablename__ = 'users'
    id = Column(Integer, primary_key=True)
    name = Column(String(50))

    def __repr__(self):
        return f"<User(id={self.id}, name='{self.name}')>"

# Create table
Base.metadata.create_all(engine)

# Raw INSERT query
insert_sql = text("INSERT INTO users (name) VALUES (:name)")
session.execute(insert_sql, {"name": "LegendMB"})
session.commit()

# Raw SELECT query
select_sql = text("SELECT * FROM users")
result = session.execute(select_sql)

# Convert to ORM-style objects manually
print("\nSelected Users:")
for row in result:
    user = User(id=row.id, name=row.name)  # manually mapping
    print(user)  # uses __repr__
