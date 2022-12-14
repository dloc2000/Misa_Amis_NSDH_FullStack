import {createRouter, createWebHistory} from 'vue-router'
import OverView from '@/view/overview/OverView'
import DepositMoney from '@/view/overview/DepositMoney'
import EmployeeList from '@/view/employees/EmployeeList'


//B1: Định nghĩa các router:
const routers = [
    { path: '/',  redirect: '/employees' },
    {path: "/tong-quan",component:OverView},
    {path: "/employees",component:EmployeeList},
    {path: "/tien-gui",component:DepositMoney},
    {path: "/mua-hang"},
    {path: "/ban-hang"},
    {path: "/quan-ly-hoa-don"},
    {path: "/kho"},
    {path: "/cong-cu"},
    {path: "/tai-san-co-dinh"},
    {path: "/tien-luong"},
    {path: "/thue"},
]

//B2: Khởi tạo router
export const router = createRouter({
    history:createWebHistory(),
    routes:routers
})