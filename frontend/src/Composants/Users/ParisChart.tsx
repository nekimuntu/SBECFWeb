import { Bar, BarChart, CartesianGrid, Legend, Tooltip, XAxis, YAxis } from "recharts";
import { Container, Header } from "semantic-ui-react";

export default function ParisChart() {
    const dateMise = new Date("2023-07-07 17:31:53.9950000");
    console.log(dateMise.getMonth());
    const data = [
                    {name: 'Janvier', Montant: 212.5, pv: 2400, amt: 2400}, 
                    {name: 'Fevrier', Montant: 200, pv: 2400, amt: 2400}, 
                    {name: 'Mars', Montant: 100, pv: 2400, amt: 2400}, 
                    {name: 'Avril', Montant: 50, pv: 2400, amt: 2400}, 
                ];
    // const result = data.map((row,index) =>{
    //     var max = 0;
    //     if(index===0) max=row.Montant;
    //     else if(row.Montant>max) max=row.Montant;
    //     return max;
    // })
    const height = 300;

    return (<>
        <Container position="center" style={{ marginTop: '5em' }} >
            <Header textAlign="center" content="HISTORIQUE DES MISES" />
            <BarChart width={900} height={height} data={data}>
                <XAxis dataKey="name" stroke="#8884d8" />
                <YAxis />
                <Tooltip wrapperStyle={{ width: 100, backgroundColor: '#ccc' }} />
                <Legend width={100} wrapperStyle={{ top: 40, right: 20, backgroundColor: '#f5f5f5', border: '1px solid #d5d5d5', borderRadius: 3, lineHeight: '40px' }} />
                <CartesianGrid stroke="#ccc" strokeDasharray="5 5" />
                <Bar dataKey="Montant" fill="#8884d8" barSize={30} />
            </BarChart>
        </Container>

    </>);
}