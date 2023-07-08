﻿import React, { Component, MouseEventHandler } from 'react'
import { Link, NavLink, Navigate, useNavigate } from 'react-router-dom'
import { Menu, Segment, Button, MenuItemProps, Dropdown, Image } from 'semantic-ui-react'
import ListJeux from './Jeu/ListJeux';
import { useStore } from '../Fonctions/Store/store';
import LoginForm from './Form/LoginForm';

export default function SBMenu() {
    const navigation = useNavigate();
    function handleClik(): void {
        navigation("/TousLesMatch");
    }

    // handleItemClick = (e:MouseEventHandler, { name }:MenuItemProps) => this.setState({ activeItem: name })
    const { usersStore,modalStore } = useStore();
    
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

                {!usersStore.isLoggedIn ?
                    (<Menu.Item position='right' >
                        <Button as={Link} onClick={()=>modalStore.openModal(<LoginForm />)}  primary>Se connecter</Button>

                    </Menu.Item>)
                    :
                    (
                        <Menu.Item position="right">
                            <Image src={"/assets/pict/NFL.jpg"} avatar spaced='right' />
                            <Dropdown pointing='top left' text={usersStore.user?.nom} >
                                <Dropdown.Menu>
                                    <Dropdown.Item as={Link} to={`/profile/${usersStore.user?.username}`} text="Profile" icon='user' />
                                    <Dropdown.Item onClick={usersStore.logout} text='Logout' icon='power' />
                                </Dropdown.Menu>

                            </Dropdown>
                        </Menu.Item>
                    )
                }


            </Menu>
        </Segment>
    )
}