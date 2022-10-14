import IRental from "../http/data/IRental"

type RentalTableProps = {
    items: IRental[]
}

export const RentalTable = ({ items }: RentalTableProps) => 
    <table className='table table-striped'>
        <thead>
            <tr>
                <th>Id</th>
                <th>Pickup date</th>
                <th>Return date</th>
                <th>Price</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            {items.length === 0
                ? <p>Nothing is here!</p>
                : items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.pickupDateTime.toString()}</td>
                        <td>{item.returnDateTime.toString()}</td>
                        <td>{item.price}</td>
                        <td></td>
                    </tr>
                )}
        </tbody>
    </table>