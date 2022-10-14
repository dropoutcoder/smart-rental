import ICar from "../http/data/ICar";

type CarTableProps = {
    items: ICar[]
}

export const CarTable = ({ items }: CarTableProps) => 
    <table className='table table-striped'>
        <thead>
            <tr>
                <th>Id</th>
                <th>Registration Number</th>
                <th>Name</th>
            </tr>
        </thead>
        <tbody>
            {items.length === 0
                ? <p>Nothing is here!</p>
                : items.map(item =>
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.registrationNumber}</td>
                        <td>{item.name}</td>
                    </tr>
                )}
        </tbody>
    </table>