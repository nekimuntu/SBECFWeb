import { Container, Tab } from "semantic-ui-react";
import UserDetails from "./UserDetails";
import ParisChart from "./ParisChart";

const panes = [
    { menuItem: 'Mon Profil', render: () => <Tab.Pane><UserDetails /></Tab.Pane> },
    { menuItem: 'Historique des paris', render: () => <Tab.Pane><ParisChart /></Tab.Pane> },
  ]
  
const MySpaceDashboard = () => <Tab panes={panes} />
export default  MySpaceDashboard;