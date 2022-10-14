import ICustomer from "../http/data/ICustomer"


type CustomerTableProps = {
    items: ICustomer[]
}

export const CustomerTable = ({ items }: CustomerTableProps) => 
    <table className='table table-striped'>
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Address</th>
                <th>Date of birth</th>
            </tr>
        </thead>
        <tbody>
            {items.length === 0
                ? <p>Nothing is here!</p>
                : items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{[item.givenName, item.surname].join(' ')}</td>
                        <td>{[item.address.street, item.address.city, item.address.postalCode].join(', ')}</td>
                        <td>{item.dateOfBirth.toString()}</td>
                    </tr>
                )}
        </tbody>
    </table>