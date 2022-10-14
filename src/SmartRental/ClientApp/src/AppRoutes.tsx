import { CarsPage } from "./pages/CarsPage";
import { CustomersPage } from "./pages/CustomersPage";
import { RentalsPage } from "./pages/RentalsPage";

const AppRoutes = [
    {
        index: true,
        element: <RentalsPage />
    },
    {
        path: '/cars',
        element: <CarsPage />
    },
    {
        path: '/customers',
        element: <CustomersPage />
    }
];

export default AppRoutes;
