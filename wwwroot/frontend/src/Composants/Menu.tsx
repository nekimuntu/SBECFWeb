import React, { Component, MouseEventHandler } from 'react'
import { Link, NavLink, Navigate, useNavigate } from 'react-router-dom'
import { Menu, Segment, Button, MenuItemProps } from 'semantic-ui-react'
import ListJeux from './Jeu/ListJeux';

export default function SBMenu()  {
    const navigation = useNavigate();
    function handleClik():void {
        navigation("/TousLesMatch");
    }

    // handleItemClick = (e:MouseEventHandler, { name }:MenuItemProps) => this.setState({ activeItem: name })
    
   
        
        
        
        return (
            <Segment inverted>
                <Menu inverted secondary>
                    <Menu.Item
                        content="Parier"
                        name='parier'
                        
                        // onClick={this.handleItemClick}
                        
                    />
                    {/* <Menu.Item
                        name='messages'
                        active={activeItem === 'messages'}
                        onClick={this.handleItemClick}
                    /> */}
                    <Menu.Item
                        content="Tous les match"
                        name='allgames'
                        
                        onClick={handleClik}
                    />
                   
                    <Menu.Item position='right' >
                        <Button  primary>Se connecter</Button>
                        
                    </Menu.Item>

                    
                </Menu>
            </Segment>
        )
}